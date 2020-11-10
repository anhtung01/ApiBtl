using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TextlevelBusiness : ITextlevelBusiness
    {
        private ITextlevelRepository _res;
        public TextlevelBusiness(ITextlevelRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(TextlevelModel model)
        {
            return _res.Update(model);
        }
        public bool Create(TextlevelModel model)
        {
            return _res.Create(model);
        }
        public TextlevelModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TextlevelModel> Search(int pageIndex, int pageSize, out long total, string textLevelName)
        {
            return _res.Search(pageIndex, pageSize, out total, textLevelName);
        }
        public List<TextlevelModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
