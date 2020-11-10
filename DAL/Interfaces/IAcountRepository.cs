using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IAcountRepository
    {
        bool Create(AcountModel model);
        bool Update(AcountModel model);
        bool Delete(string id);
        AcountModel GetDatabyID(string id);
        List<AcountModel> GetDataAll();
        List<AcountModel> Search(int pageIndex, int pageSize, out long total, string username);
    }
}
