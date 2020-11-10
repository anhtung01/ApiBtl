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
    public class TexttoController : ControllerBase
    {
        private ITexttoBusiness _itemBusiness;
        public TexttoController(ITexttoBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TexttoModel CreateItem([FromBody] TexttoModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TexttoModel GetDatabyID(string id)
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
                string texttoid = "";
                if (formData.Keys.Contains("texttoid") && !string.IsNullOrEmpty(Convert.ToString(formData["texttoid"]))) { texttoid = Convert.ToString(formData["texttoid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, texttoid);
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

        [Route("delete-Textto")]
        [HttpPost]
        public IActionResult DeleteTextto([FromBody] Dictionary<string, object> formData)
        {
            string texttoid = "";
            if (formData.Keys.Contains("texttoid") && !string.IsNullOrEmpty(Convert.ToString(formData["texttoid"]))) { texttoid = Convert.ToString(formData["texttoid"]); }
            _itemBusiness.Delete(texttoid);
            return Ok();
        }

        [Route("update-Textto")]
        [HttpPost]
        public TexttoModel UpdateTextto([FromBody] TexttoModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TexttoModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
