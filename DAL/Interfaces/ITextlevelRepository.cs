using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITextlevelRepository
    {
        bool Create(TextlevelModel model);
        bool Update(TextlevelModel model);
        bool Delete(string id);
        TextlevelModel GetDatabyID(string id);
        List<TextlevelModel> GetDataAll();
        List<TextlevelModel> Search(int pageIndex, int pageSize, out long total, string textLevelName);
    }
}
