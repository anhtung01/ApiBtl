using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDepartmentRepository
    {
        bool Create(DepartmentModel model);
        bool Update(DepartmentModel model);
        bool Delete(string id);
        DepartmentModel GetDatabyID(string id);
        List<DepartmentModel> Search(int pageIndex, int pageSize, out long total, string departmentname);
        List<DepartmentModel> GetDataAll();
       
    }
}
