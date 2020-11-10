using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class DepartmentBusiness : IDepartmentBusiness
    {
        private IDepartmentRepository _res;
        public DepartmentBusiness(IDepartmentRepository itemBusiness)
        {
            _res = itemBusiness;
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(DepartmentModel model)
        {
            return _res.Update(model);
        }
        public bool Create(DepartmentModel model)
        {
            return _res.Create(model);
        }
        public DepartmentModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DepartmentModel> Search(int pageIndex, int pageSize, out long total, string departmentname)
        {
            return _res.Search(pageIndex, pageSize, out total, departmentname);
        }
        public List<DepartmentModel> GetDataAll()
        {
            return _res.GetDataAll();
        } 
    }
}
