using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TextinboxBusiness : ITextinboxBusiness
    {
        private ITextinboxRepository _res;
        public TextinboxBusiness(ITextinboxRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TextinboxModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TextinboxModel model)
        {
            return _res.Create(model);
        }
        public TextinboxModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TextinboxModel> Search(int pageIndex, int pageSize, out long total, string textinboxid)
        {
            return _res.Search(pageIndex, pageSize, out total, textinboxid);
        }
        public List<TextinboxModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
