using System;
using System.Data;
using BaltaStore.Shared;
using System.Data.SqlClient;

namespace BaltaStore.Infra.StoreContext.DataContexts
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}