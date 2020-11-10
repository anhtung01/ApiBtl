using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IOwneradminBusiness
    {
        bool Update(OwneradminModel model);
        bool Delete(string id);
        bool Create(OwneradminModel model);
        OwneradminModel GetDatabyID(string id);
        List<OwneradminModel> Search(int pageIndex, int pageSize, out long total, string owneradminid);
        List<OwneradminModel> GetDataAll();
    }
}
