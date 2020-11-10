using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITextinboxRepository
    {
        bool Create(TextinboxModel model);
        bool Update(TextinboxModel model);
        bool Delete(string id);
        TextinboxModel GetDatabyID(string id);
        List<TextinboxModel> GetDataAll();
        List<TextinboxModel> Search(int pageIndex, int pageSize, out long total, string textinboxid);
    }
}
