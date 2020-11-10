using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class GroupacountBusiness : IGroupacountBusiness
    {
        private IGroupacountRepository _res;
        public GroupacountBusiness(IGroupacountRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(GroupacountModel model)
        {
            return _res.Update(model);
        }
        public bool Create(GroupacountModel model)
        {
            return _res.Create(model);
        }
        public GroupacountModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<GroupacountModel> Search(int pageIndex, int pageSize, out long total, string groupacountname)
        {
            return _res.Search(pageIndex, pageSize, out total, groupacountname);
        }
        public List<GroupacountModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
