using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IStaffBusiness
    {
        bool Update(StaffModel model);
        bool Delete(string id);
        bool Create(StaffModel model);
        StaffModel GetDatabyID(string id);
        List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffid);
        List<StaffModel> GetDataAll();
    }
}
