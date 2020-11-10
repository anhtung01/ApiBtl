using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IAcountBusiness
    {
        bool Update(AcountModel model);
        bool Delete(string id);
        bool Create(AcountModel model);
        AcountModel GetDatabyID(string id);
        List<AcountModel> Search(int pageIndex, int pageSize, out long total, string username);
        List<AcountModel> GetDataAll();
    }
}
