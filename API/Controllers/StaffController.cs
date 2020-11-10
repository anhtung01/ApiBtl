using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IStaffBusiness _itemBusiness;
        public StaffController(IStaffBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public StaffModel CreateItem([FromBody] StaffModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public StaffModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string staffid = "";
                if (formData.Keys.Contains("staffid") && !string.IsNullOrEmpty(Convert.ToString(formData["staffid"]))) { staffid = Convert.ToString(formData["staffid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, staffid);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("delete-Staff")]
        [HttpPost]
        public IActionResult DeleteStaff([FromBody] Dictionary<string, object> formData)
        {
            string staffid = "";
            if (formData.Keys.Contains("staffid") && !string.IsNullOrEmpty(Convert.ToString(formData["staffid"]))) { staffid = Convert.ToString(formData["staffid"]); }
            _itemBusiness.Delete(staffid);
            return Ok();
        }

        [Route("update-Staff")]
        [HttpPost]
        public StaffModel UpdateStaff([FromBody] StaffModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<StaffModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
