using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IOwneradminRepository
    {
        bool Create(OwneradminModel model);
        bool Update(OwneradminModel model);
        bool Delete(string id);
        OwneradminModel GetDatabyID(string id);
        List<OwneradminModel> GetDataAll();
        List<OwneradminModel> Search(int pageIndex, int pageSize, out long total, string owneradminid);
    }
}
