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
    public class TextsController : ControllerBase
    {
        private ITextsBusiness _itemBusiness;
        public TextsController(ITextsBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TextsModel CreateItem([FromBody] TextsModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TextsModel GetDatabyID(string id)
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
                string textid = "";
                if (formData.Keys.Contains("textid") && !string.IsNullOrEmpty(Convert.ToString(formData["textid"]))) { textid = Convert.ToString(formData["textid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, textid);
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

        [Route("delete-Texts")]
        [HttpPost]
        public IActionResult DeleteTexts([FromBody] Dictionary<string, object> formData)
        {
            string textid = "";
            if (formData.Keys.Contains("textid") && !string.IsNullOrEmpty(Convert.ToString(formData["textid"]))) { textid = Convert.ToString(formData["textid"]); }
            _itemBusiness.Delete(textid);
            return Ok();
        }

        [Route("update-Texts")]
        [HttpPost]
        public TextsModel UpdateTexts([FromBody] TextsModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TextsModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
