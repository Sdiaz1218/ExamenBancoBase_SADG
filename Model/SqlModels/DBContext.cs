using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamenBancoBase.SqlModels
{
    public class DBContext : IDBContext
    {
        private readonly IConfiguration _configuration;
        private SqlConnection? cnx = null;
        private SqlTransaction? tr = null;
        int cmdTimeOut = 0;
        public DBContext(IConfiguration configuration)
        {
            Console.WriteLine("XContext.New");
            _configuration = configuration;
            cnx = new SqlConnection(configuration.GetConnectionString("PagosConn"));
            cnx.Open();
        }
        public void BeginTrx()
        {
            tr = cnx!.BeginTransaction();

        }

        public void Close()
        {
            if (cnx != null) cnx.Close();
            cnx = null;
        }

        public void CommitTrx()
        {
            if (tr == null) return;
            tr.Commit();
            tr = null;
        }

        public object ExecScalar(string sql)
        {
            //ShowDebugSql(sql);
            SqlCommand? cmd = null;
            if (tr == null)
                cmd = new SqlCommand(sql, cnx);
            else
                cmd = new SqlCommand(sql, cnx, tr); cmd.CommandTimeout = cmdTimeOut;
            object obj = cmd.ExecuteScalar();
            cmd.Dispose();
            return obj;
        }

        public int ExecSql(string sql)
        {
            //ShowDebugSql(sql);
            SqlCommand? cmd = null;
            if (tr == null)
                cmd = new SqlCommand(sql, cnx);
            else
                cmd = new SqlCommand(sql, cnx, tr); cmd.CommandTimeout = cmdTimeOut;
            int num = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return num;
        }

        public DataSet GetDataSet(string sql)
        {
            SqlCommand? cmd = null;
            if (tr == null)
                cmd = new SqlCommand(sql, cnx);
            else
                cmd = new SqlCommand(sql, cnx, tr);
            cmd.CommandTimeout = cmdTimeOut;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, "Tabla");
            adp.Dispose();
            cmd.Dispose();
            return ds;
        }

        public DataTable GetTable(string sql)
        {
            throw new NotImplementedException();
        }

        public DataTable GetTable(string sql, string nombre, DataSet ds)
        {
            throw new NotImplementedException();
        }

        public void RollbackTrx()
        {
            throw new NotImplementedException();
        }

        public void TrySql(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
