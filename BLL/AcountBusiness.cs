using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class AcountBusiness : IAcountBusiness
    {
        private IAcountRepository _res;
        public AcountBusiness(IAcountRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(AcountModel model)
        {
            return _res.Update(model);
        }
        public bool Create(AcountModel model)
        {
            return _res.Create(model);
        }
        public AcountModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<AcountModel> Search(int pageIndex, int pageSize, out long total, string username)
        {
            return _res.Search(pageIndex, pageSize, out total, username);
        }
        public List<AcountModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
