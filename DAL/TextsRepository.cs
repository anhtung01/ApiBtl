using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class TextsRepository : ITextsRepository
    {
        private IDatabaseHelper _dbHelper;
        public TextsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(TextsModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "texts_item_create",
                "@textid", model.textid,
                "@typetextid", model.typetextid,
                "@isinternaldocuments", model.isinternaldocuments,
                "@departmentaddressid", model.departmentaddressid,
                "@datecreate", model.datecreate,
                "@signer", model.signer,
                "@textlevelid", model.textlevelid,
                "@needtreated", model.needtreated,
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
        public TextsModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "texts_item_get_by_id",
                     "@textid", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TextsModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TextsModel> Search(int pageIndex, int pageSize, out long total, string textid)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "texts_item_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@textid", textid);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TextsModel>().ToList();
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "texts_delete",
                "@textid", id);
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
        public bool Update(TextsModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "texts_update",
                "@textid", model.textid,
                "@typetextid", model.typetextid,
                "@isinternaldocuments", model.isinternaldocuments,
                "@departmentaddressid", model.departmentaddressid,
                "@datecreate", model.datecreate,
                "@signer", model.signer,
                "@textlevelid", model.textlevelid,
                "@needtreated", model.needtreated,
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

        public List<TextsModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "texts_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TextsModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
