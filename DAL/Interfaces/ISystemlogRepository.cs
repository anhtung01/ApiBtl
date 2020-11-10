using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISystemlogRepository
    {
        bool Create(SystemlogModel model);
        bool Update(SystemlogModel model);
        bool Delete(string id);
        SystemlogModel GetDatabyID(string id);
        List<SystemlogModel> GetDataAll();
        List<SystemlogModel> Search(int pageIndex, int pageSize, out long total, string username);
    }
}
