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
    public class OwneradminController : ControllerBase
    {
        private IOwneradminBusiness _itemBusiness;
        public OwneradminController(IOwneradminBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public OwneradminModel CreateItem([FromBody] OwneradminModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public OwneradminModel GetDatabyID(string id)
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
                string owneradminid = "";
                if (formData.Keys.Contains("owneradminid") && !string.IsNullOrEmpty(Convert.ToString(formData["owneradminid"]))) { owneradminid = Convert.ToString(formData["owneradminid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, owneradminid);
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

        [Route("delete-Owneradmin")]
        [HttpPost]
        public IActionResult DeleteOwneradmin([FromBody] Dictionary<string, object> formData)
        {
            string owneradminid = "";
            if (formData.Keys.Contains("owneradminid") && !string.IsNullOrEmpty(Convert.ToString(formData["owneradminid"]))) { owneradminid = Convert.ToString(formData["owneradminid"]); }
            _itemBusiness.Delete(owneradminid);
            return Ok();
        }

        [Route("update-Owneradmin")]
        [HttpPost]
        public OwneradminModel UpdateOwneradmin([FromBody] OwneradminModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<OwneradminModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
