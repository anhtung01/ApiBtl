using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ISystemlogBusiness
    {
        bool Update(SystemlogModel model);
        bool Delete(string id);
        bool Create(SystemlogModel model);
        SystemlogModel GetDatabyID(string id);
        List<SystemlogModel> Search(int pageIndex, int pageSize, out long total, string systemlogid);
        List<SystemlogModel> GetDataAll();
    }
}
