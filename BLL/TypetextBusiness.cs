using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TypetextBusiness : ITypetextBusiness
    {
        private ITypetextRepository _res;
        public TypetextBusiness(ITypetextRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TypetextModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TypetextModel model)
        {
            return _res.Create(model);
        }
        public TypetextModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TypetextModel> Search(int pageIndex, int pageSize, out long total, string typetextname)
        {
            return _res.Search(pageIndex, pageSize, out total, typetextname);
        }
        public List<TypetextModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
