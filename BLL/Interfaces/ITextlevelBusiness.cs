using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITextlevelBusiness
    {
        bool Update(TextlevelModel model);
        bool Delete(string id);
        bool Create(TextlevelModel model);
        TextlevelModel GetDatabyID(string id);
        List<TextlevelModel> Search(int pageIndex, int pageSize, out long total, string textLevelName);
        List<TextlevelModel> GetDataAll();
    }
}
