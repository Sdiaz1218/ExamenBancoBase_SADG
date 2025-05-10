using System.Data;

namespace ExamenBancoBase.SqlModels
{
    public interface IDBContext
    {
        void Close();
        void BeginTrx();
        void CommitTrx();
        void RollbackTrx();
        int ExecSql(string sql);
        object ExecScalar(string sql);
        void TrySql(string sql);
        DataTable GetTable(string sql);
        DataTable GetTable(string sql, string nombre, DataSet ds);
        DataSet GetDataSet(string sql);
    }
}
