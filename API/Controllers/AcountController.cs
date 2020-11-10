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
    public class AcountController : ControllerBase
    { 
        private IAcountBusiness _itemBusiness;
        public AcountController(IAcountBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public AcountModel CreateItem([FromBody] AcountModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public AcountModel GetDatabyID(string id)
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
                string username = "";
                if (formData.Keys.Contains("username") && !string.IsNullOrEmpty(Convert.ToString(formData["username"]))) { username = Convert.ToString(formData["username"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, username);
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
            string acountid = "";
            if (formData.Keys.Contains("acountid") && !string.IsNullOrEmpty(Convert.ToString(formData["acountid"]))) { acountid = Convert.ToString(formData["acountid"]); }
            _itemBusiness.Delete(acountid);
            return Ok();
        }

        [Route("update-acount")]
        [HttpPost]
        public AcountModel UpdateAcount([FromBody] AcountModel model)
        { 
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<AcountModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
