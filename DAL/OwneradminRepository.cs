using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class OwneradminRepository : IOwneradminRepository
    {
        private IDatabaseHelper _dbHelper;
        public OwneradminRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(OwneradminModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "owneradmin_item_create",
                "@owneradminid", model.owneradminid,
                "@acountid", model.acountid,
                "@all1", model.all1,
                "@departmentreadonly", model.departmentreadonly,
                "@departmentmodify", model.departmentmodify,
                "@departmentdelate", model.departmentdelate,
                "@departmentcreat", model.departmentcreat,
                "@groupuseradmin", model.groupuseradmin,
                "@staffreadonly", model.staffreadonly,
                "@staffmodify", model.staffmodify,
                "@staffdelete", model.staffdelete,
                "@stafflreat", model.stafflreat,
                "@systemlogview", model.systemlogview,
                "@systemlogdelete", model.systemlogdelete
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
        public OwneradminModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "owneradmin_item_get_by_id",
                     "@owneradminid", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<OwneradminModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OwneradminModel> Search(int pageIndex, int pageSize, out long total, string owneradminid)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "owneradmin_item_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@owneradminid", owneradminid);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<OwneradminModel>().ToList();
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "owneradmin_delete",
                "@owneradminid", id);
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
        public bool Update(OwneradminModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "owneradmin_update",
                "@owneradminid", model.owneradminid,
                "@acountid", model.acountid,
                "@all1", model.all1,
                "@departmentreadonly", model.departmentreadonly,
                "@departmentmodify", model.departmentmodify,
                "@departmentdelate", model.departmentdelate,
                "@departmentcreat", model.departmentcreat,
                "@groupuseradmin", model.groupuseradmin,
                "@staffreadonly", model.staffreadonly,
                "@staffmodify", model.staffmodify,
                "@staffdelete", model.staffdelete,
                "@stafflreat", model.stafflreat,
                "@systemlogview", model.systemlogview,
                "@systemlogdelete", model.systemlogdelete
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

        public List<OwneradminModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "owneradmin_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<OwneradminModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
