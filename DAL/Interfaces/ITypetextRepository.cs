using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITypetextRepository
    {
        bool Create(TypetextModel model);
        bool Update(TypetextModel model);
        bool Delete(string id);
        TypetextModel GetDatabyID(string id);
        List<TypetextModel> GetDataAll();
        List<TypetextModel> Search(int pageIndex, int pageSize, out long total, string typetextname);
    }
}
