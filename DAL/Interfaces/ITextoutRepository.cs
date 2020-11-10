using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITextoutRepository
    {
        bool Create(TextoutModel model);
        bool Update(TextoutModel model);
        bool Delete(string id);
        TextoutModel GetDatabyID(string id);
        List<TextoutModel> GetDataAll();
        List<TextoutModel> Search(int pageIndex, int pageSize, out long total, string textoutid);
    }
}
