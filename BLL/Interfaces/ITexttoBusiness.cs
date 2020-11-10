using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITexttoBusiness
    {
        bool Update(TexttoModel model);
        bool Delete(string id);
        bool Create(TexttoModel model);
        TexttoModel GetDatabyID(string id);
        List<TexttoModel> Search(int pageIndex, int pageSize, out long total, string texttoid);
        List<TexttoModel> GetDataAll();
    }
}
