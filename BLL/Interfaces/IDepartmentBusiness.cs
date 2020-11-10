using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IDepartmentBusiness
    {
        bool Update(DepartmentModel model);
        bool Delete(string id);
        bool Create(DepartmentModel model);
        DepartmentModel GetDatabyID(string id);
        List<DepartmentModel> Search(int pageIndex, int pageSize, out long total, string departmentname);
        List<DepartmentModel> GetDataAll();
    }
}