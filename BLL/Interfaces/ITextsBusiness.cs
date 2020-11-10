using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITextsBusiness
    {
        bool Update(TextsModel model);
        bool Delete(string id);
        bool Create(TextsModel model);
        TextsModel GetDatabyID(string id);
        List<TextsModel> Search(int pageIndex, int pageSize, out long total, string textid);
        List<TextsModel> GetDataAll();
    }
}
