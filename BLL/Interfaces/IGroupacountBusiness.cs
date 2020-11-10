using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IGroupacountBusiness
    {
        bool Update(GroupacountModel model);
        bool Delete(string id);
        bool Create(GroupacountModel model);
        GroupacountModel GetDatabyID(string id);
        List<GroupacountModel> Search(int pageIndex, int pageSize, out long total, string groupacountname);
        List<GroupacountModel> GetDataAll();
    }
}
