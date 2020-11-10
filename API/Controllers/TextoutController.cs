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
    public class TextoutController : ControllerBase
    {
        private ITextoutBusiness _itemBusiness;
        public TextoutController(ITextoutBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public TextoutModel CreateItem([FromBody] TextoutModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public TextoutModel GetDatabyID(string id)
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
                string textoutid = "";
                if (formData.Keys.Contains("textoutid") && !string.IsNullOrEmpty(Convert.ToString(formData["textoutid"]))) { textoutid = Convert.ToString(formData["textoutid"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, textoutid);
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

        [Route("delete-textout")]
        [HttpPost]
        public IActionResult DeleteAcount([FromBody] Dictionary<string, object> formData)
        {
            string textoutid = "";
            if (formData.Keys.Contains("textoutid") && !string.IsNullOrEmpty(Convert.ToString(formData["textoutid"]))) { textoutid = Convert.ToString(formData["textoutid"]); }
            _itemBusiness.Delete(textoutid);
            return Ok();
        }

        [Route("update-textout")]
        [HttpPost]
        public TextoutModel UpdateAcount([FromBody] TextoutModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TextoutModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
