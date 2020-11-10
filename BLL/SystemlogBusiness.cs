using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class SystemlogBusiness : ISystemlogBusiness
    {
        private ISystemlogRepository _res;
        public SystemlogBusiness(ISystemlogRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SystemlogModel model)
        {
            return _res.Update(model);
        }
        public bool Create(SystemlogModel model)
        {
            return _res.Create(model);
        }
        public SystemlogModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SystemlogModel> Search(int pageIndex, int pageSize, out long total, string systemlogid)
        {
            return _res.Search(pageIndex, pageSize, out total, systemlogid);
        }
        public List<SystemlogModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
