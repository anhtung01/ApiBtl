using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TextoutBusiness : ITextoutBusiness
    {
        private ITextoutRepository _res;
        public TextoutBusiness(ITextoutRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TextoutModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TextoutModel model)
        {
            return _res.Create(model);
        }
        public TextoutModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TextoutModel> Search(int pageIndex, int pageSize, out long total, string textoutid)
        {
            return _res.Search(pageIndex, pageSize, out total, textoutid);
        }
        public List<TextoutModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
