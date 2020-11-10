using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITextoutBusiness
    {
        bool Update(TextoutModel model);
        bool Delete(string id);
        bool Create(TextoutModel model);
        TextoutModel GetDatabyID(string id);
        List<TextoutModel> Search(int pageIndex, int pageSize, out long total, string textoutid);
        List<TextoutModel> GetDataAll();
    }
}
