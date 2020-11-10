using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class StaffBusiness : IStaffBusiness
    {
        private IStaffRepository _res;
        public StaffBusiness(IStaffRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(StaffModel model)
        {
            return _res.Update(model);
        }
        public bool Create(StaffModel model)
        {
            return _res.Create(model);
        }
        public StaffModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffid)
        {
            return _res.Search(pageIndex, pageSize, out total, staffid);
        }
        public List<StaffModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
