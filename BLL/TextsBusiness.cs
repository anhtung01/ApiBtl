using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TextsBusiness : ITextsBusiness
    {
        private ITextsRepository _res;
        public TextsBusiness(ITextsRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TextsModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TextsModel model)
        {
            return _res.Create(model);
        }
        public TextsModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TextsModel> Search(int pageIndex, int pageSize, out long total, string textid)
        {
            return _res.Search(pageIndex, pageSize, out total, textid);
        }
        public List<TextsModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
