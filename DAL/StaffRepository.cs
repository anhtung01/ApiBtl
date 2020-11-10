using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class StaffRepository : IStaffRepository
    {
        private IDatabaseHelper _dbHelper;
        public StaffRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(StaffModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "staff_item_create",
                "@staffid", model.staffid,
                "@departmentid", model.departmentid,
                "@ischarge", model.ischarge,
                "@staffname", model.staffname,
                "@birthday", model.birthday,
                "@addresss", model.addresss,
                "@phonenumber", model.phonenumber,
                "@acountid", model.acountid,
                "@emailaddress", model.emailaddress,
                "@isdeleted", model.isdeleted);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StaffModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "staff_item_get_by_id",
                     "@staffid", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StaffModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffModel> Search(int pageIndex, int pageSize, out long total, string staffid)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "staff_item_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@staffid", staffid);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<StaffModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "staff_delete",
                "@staffid", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(StaffModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "staff_update",
                "@staffid", model.staffid,
                "@departmentid", model.departmentid,
                "@ischarge", model.ischarge,
                "@staffname", model.staffname,
                "@birthday", model.birthday,
                "@addresss", model.addresss,
                "@phonenumber", model.phonenumber,
                "@acountid", model.acountid,
                "@emailaddress", model.emailaddress,
                "@isdeleted", model.isdeleted
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "staff_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<StaffModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
