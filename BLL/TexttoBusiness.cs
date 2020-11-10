using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TexttoBusiness : ITexttoBusiness
    {
        private ITexttoRepository _res;
        public TexttoBusiness(ITexttoRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TexttoModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TexttoModel model)
        {
            return _res.Create(model);
        }
        public TexttoModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TexttoModel> Search(int pageIndex, int pageSize, out long total, string texttoid)
        {
            return _res.Search(pageIndex, pageSize, out total, texttoid);
        }
        public List<TexttoModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
