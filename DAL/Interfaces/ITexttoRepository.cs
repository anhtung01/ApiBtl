using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITexttoRepository
    {
        bool Create(TexttoModel model);
        bool Update(TexttoModel model);
        bool Delete(string id);
        TexttoModel GetDatabyID(string id);
        List<TexttoModel> GetDataAll();
        List<TexttoModel> Search(int pageIndex, int pageSize, out long total, string texttoid);
    }
}
