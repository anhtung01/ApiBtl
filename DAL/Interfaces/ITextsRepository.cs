using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITextsRepository
    {
        bool Create(TextsModel model);
        bool Update(TextsModel model);
        bool Delete(string id);
        TextsModel GetDatabyID(string id);
        List<TextsModel> GetDataAll();
        List<TextsModel> Search(int pageIndex, int pageSize, out long total, string textid);
    }
}
