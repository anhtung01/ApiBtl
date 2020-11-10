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
    public class SystemlogController : ControllerBase
    {
        private ISystemlogBusiness _itemBusiness;
        public SystemlogController(ISystemlogBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public SystemlogModel CreateItem([FromBody] SystemlogModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SystemlogModel GetDatabyID(string id)
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
                string systemlogid = "";
                if (formData.Keys.Contains("systemlogid") && !string.IsNullOrEmpty(Convert.ToString(formData["systemlogid"]))) { systemlogid = Convert.ToString(formData["systemlogid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, systemlogid);
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

        [Route("delete-Systemlog")]
        [HttpPost]
        public IActionResult DeleteSystemlog([FromBody] Dictionary<string, object> formData)
        {
            string systemlogid = "";
            if (formData.Keys.Contains("systemlogid") && !string.IsNullOrEmpty(Convert.ToString(formData["systemlogid"]))) { systemlogid = Convert.ToString(formData["systemlogid"]); }
            _itemBusiness.Delete(systemlogid);
            return Ok();
        }

        [Route("update-Systemlog")]
        [HttpPost]
        public SystemlogModel UpdateSystemlog([FromBody] SystemlogModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SystemlogModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
