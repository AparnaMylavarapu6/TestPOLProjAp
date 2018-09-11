using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RentersInsuranceApiTests.Controllers
{
    public class DatabaseController
    {
        public SqlConnection openConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return conn;
        }

        public DataTable executeQuery(SqlConnection conn, string query)
        {
            var dap = new SqlDataAdapter(query, conn);
            var ds = new DataSet();
            dap.Fill(ds);
            return ds.Tables[0];
        }

        public bool executeCommand(SqlConnection conn, string commandSql)
        {
            var ret = false;
            var cmd = new SqlCommand();
            try
            {
                var da = new SqlDataAdapter();
                da.UpdateCommand = new SqlCommand(commandSql, conn);
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
                ret = false;
            }
            finally
            {
                cmd.Dispose();
                ret = true;
            }

            return ret;
        }

        public DataSet executeStoredProcedure(SqlConnection conn, string sql, bool doRollback,
            List<KeyValuePair<string, string>> paramsList)
        {
            var ds = new DataSet();

            #region build sql string

            var sb = new StringBuilder();
            if (doRollback)
            {
                sb.Append("BEGIN TRY ");
                sb.Append("BEGIN TRAN TEST ");
            }

            sb.Append(sql);

            if (doRollback)
            {
                sb.Append(" IF  @@TRANCOUNT > 0 ROLLBACK TRAN TEST ");
                sb.Append("END TRY ");
                sb.Append("BEGIN CATCH ");
                sb.Append("SELECT ");
                sb.Append("ERROR_NUMBER() AS ErrorNumber ");
                sb.Append(",ERROR_SEVERITY() AS ErrorSeverity ");
                sb.Append(",ERROR_STATE() AS ErrorState ");
                sb.Append(",ERROR_PROCEDURE() AS ErrorProcedure ");
                sb.Append(",ERROR_LINE() AS ErrorLine ");
                sb.Append(",ERROR_MESSAGE() AS ErrorMessage ");
                sb.Append(
                    "IF EXISTS (SELECT [name] FROM sys.dm_tran_active_transactions WHERE name = 'TEST') ROLLBACK TRAN TEST ");
                sb.Append("END CATCH ");
            }

            #endregion

            var cmd = new SqlCommand();
            try
            {
                #region build sql command

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var param in paramsList) cmd.Parameters.AddWithValue(param.Key, param.Value);

                #endregion

                #region send sql command

                var da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                #endregion
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
            }
            finally
            {
                cmd.Dispose();
            }

            return ds;
        }

        public void closeConnection(SqlConnection conn)
        {
            //Close
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private string printableDataSet(DataSet ds)
        {
            string ret = null;
            ret += "Tables in '" + ds.DataSetName + "' DataSet.\n";
            foreach (DataTable dt in ds.Tables)
            {
                ret += dt.TableName + " Table.\n";
                for (var curCol = 0; curCol < dt.Columns.Count; curCol++)
                    ret += dt.Columns[curCol].ColumnName.Trim() + "\t";
                for (var curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (var curCol = 0; curCol < dt.Columns.Count; curCol++)
                        ret += dt.Rows[curRow][curCol].ToString().Trim() + "\t";
                    ret += "\n";
                }
            }

            return ret;
        }

        #region constructors

        #endregion
    }
}