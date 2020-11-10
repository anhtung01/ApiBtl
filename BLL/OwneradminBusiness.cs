using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class OwneradminBusiness : IOwneradminBusiness
    {
        private IOwneradminRepository _res;
        public OwneradminBusiness(IOwneradminRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(OwneradminModel model)
        {
            return _res.Update(model);
        }
        public bool Create(OwneradminModel model)
        {
            return _res.Create(model);
        }
        public OwneradminModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<OwneradminModel> Search(int pageIndex, int pageSize, out long total, string owneradminid)
        {
            return _res.Search(pageIndex, pageSize, out total, owneradminid);
        }
        public List<OwneradminModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
