using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IStaffRepository
    {
        bool Create(StaffModel model);
        bool Update(StaffModel model);
        bool Delete(string id);
        StaffModel GetDatabyID(string id);
        List<StaffModel> GetDataAll();
        List<StaffModel> Search(int pageIndex, int pageSize, out long total, string username);
    }
}
