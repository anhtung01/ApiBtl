using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITypetextBusiness
    {
        bool Update(TypetextModel model);
        bool Delete(string id);
        bool Create(TypetextModel model);
        TypetextModel GetDatabyID(string id);
        List<TypetextModel> Search(int pageIndex, int pageSize, out long total, string typetextname);
        List<TypetextModel> GetDataAll();
    }
}
