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
    public class DepartmentController : ControllerBase
    {
        private IDepartmentBusiness _itemBusiness;
        public DepartmentController(IDepartmentBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-item")]
        [HttpPost]
        public DepartmentModel CreateItem([FromBody] DepartmentModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DepartmentModel GetDatabyID(string id)
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
                string departmentname = "";
                if (formData.Keys.Contains("departmentname") && !string.IsNullOrEmpty(Convert.ToString(formData["departmentname"]))) { departmentname = Convert.ToString(formData["departmentname"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, departmentname);
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

        [Route("delete-acount")]
        [HttpPost]
        public IActionResult DeleteAcount([FromBody] Dictionary<string, object> formData)
        {
            string departmentid = "";
            if (formData.Keys.Contains("departmentid") && !string.IsNullOrEmpty(Convert.ToString(formData["departmentid"]))) { departmentid = Convert.ToString(formData["departmentid"]); }
            _itemBusiness.Delete(departmentid);
            return Ok();
        }

        [Route("update-acount")]
        [HttpPost]
        public DepartmentModel UpdateAcount([FromBody] DepartmentModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DepartmentModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }

    }
}
