using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITextinboxBusiness
    {
        bool Update(TextinboxModel model);
        bool Delete(string id);
        bool Create(TextinboxModel model);
        TextinboxModel GetDatabyID(string id);
        List<TextinboxModel> Search(int pageIndex, int pageSize, out long total, string textinboxid);
        List<TextinboxModel> GetDataAll();
    }
}
