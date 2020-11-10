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
    public class TypetextController : ControllerBase
    {
        private ITypetextBusiness _itemBusiness;
        public TypetextController(ITypetextBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TypetextModel CreateItem([FromBody] TypetextModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TypetextModel GetDatabyID(string id)
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
                string typetextname = "";
                if (formData.Keys.Contains("typetextname") && !string.IsNullOrEmpty(Convert.ToString(formData["typetextname"]))) { typetextname = Convert.ToString(formData["typetextname"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, typetextname);
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

        [Route("delete-Typetext")]
        [HttpPost]
        public IActionResult DeleteTypetext([FromBody] Dictionary<string, object> formData)
        {
            string typetextid = "";
            if (formData.Keys.Contains("typetextid") && !string.IsNullOrEmpty(Convert.ToString(formData["typetextid"]))) { typetextid = Convert.ToString(formData["typetextid"]); }
            _itemBusiness.Delete(typetextid);
            return Ok();
        }

        [Route("update-Typetext")]
        [HttpPost]
        public TypetextModel UpdateTypetext([FromBody] TypetextModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TypetextModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
