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
    public class TextinboxController : ControllerBase
    {
        private ITextinboxBusiness _itemBusiness;
        public TextinboxController(ITextinboxBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TextinboxModel CreateItem([FromBody] TextinboxModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TextinboxModel GetDatabyID(string id)
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
                string textinboxid = "";
                if (formData.Keys.Contains("textinboxid") && !string.IsNullOrEmpty(Convert.ToString(formData["textinboxid"]))) { textinboxid = Convert.ToString(formData["textinboxid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, textinboxid);
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

        [Route("delete-Textinbox")]
        [HttpPost]
        public IActionResult DeleteTextinbox([FromBody] Dictionary<string, object> formData)
        {
            string textinboxid = "";
            if (formData.Keys.Contains("textinboxid") && !string.IsNullOrEmpty(Convert.ToString(formData["textinboxid"]))) { textinboxid = Convert.ToString(formData["textinboxid"]); }
            _itemBusiness.Delete(textinboxid);
            return Ok();
        }

        [Route("update-Textinbox")]
        [HttpPost]
        public TextinboxModel UpdateTextinbox([FromBody] TextinboxModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TextinboxModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
