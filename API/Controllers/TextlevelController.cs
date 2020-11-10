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
    public class TextlevelController : ControllerBase
    {
        private ITextlevelBusiness _itemBusiness;
        public TextlevelController(ITextlevelBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TextlevelModel CreateItem([FromBody] TextlevelModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TextlevelModel GetDatabyID(string id)
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
                string textLevelName = "";
                if (formData.Keys.Contains("textLevelName") && !string.IsNullOrEmpty(Convert.ToString(formData["textLevelName"]))) { textLevelName = Convert.ToString(formData["textLevelName"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, textLevelName);
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

        [Route("delete-Textlevel")]
        [HttpPost]
        public IActionResult DeleteTextlevel([FromBody] Dictionary<string, object> formData)
        {
            string textlevelid = "";
            if (formData.Keys.Contains("textlevelid") && !string.IsNullOrEmpty(Convert.ToString(formData["textlevelid"]))) { textlevelid = Convert.ToString(formData["textlevelid"]); }
            _itemBusiness.Delete(textlevelid);
            return Ok();
        }

        [Route("update-Textlevel")]
        [HttpPost]
        public TextlevelModel UpdateTextlevel([FromBody] TextlevelModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TextlevelModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
