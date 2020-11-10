using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IGroupacountRepository
    {
        bool Create(GroupacountModel model);
        bool Update(GroupacountModel model);
        bool Delete(string id);
        GroupacountModel GetDatabyID(string id);
        List<GroupacountModel> GetDataAll();
        List<GroupacountModel> Search(int pageIndex, int pageSize, out long total, string groupacountname);
    }
}
