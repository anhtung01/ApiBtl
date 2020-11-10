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
    public class GroupacountController : ControllerBase
    {
        private IGroupacountBusiness _itemBusiness;
        public GroupacountController(IGroupacountBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }
        [Route("create-item")]
        [HttpPost]
        public GroupacountModel CreateItem([FromBody] GroupacountModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public GroupacountModel GetDatabyID(string id)
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
                string groupacountname = "";
                if (formData.Keys.Contains("groupacountname") && !string.IsNullOrEmpty(Convert.ToString(formData["groupacountname"]))) { groupacountname = Convert.ToString(formData["groupacountname"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, groupacountname);
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

        [Route("delete-group")]
        [HttpPost]
        public IActionResult DeleteAcount([FromBody] Dictionary<string, object> formData)
        {
            string acountid = "";
            if (formData.Keys.Contains("groupacountid") && !string.IsNullOrEmpty(Convert.ToString(formData["groupacountid"]))) { acountid = Convert.ToString(formData["groupacountid"]); }
            _itemBusiness.Delete(acountid);
            return Ok();
        }

        [Route("update-group")]
        [HttpPost]
        public GroupacountModel UpdateAcount([FromBody] GroupacountModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GroupacountModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
    }
}
