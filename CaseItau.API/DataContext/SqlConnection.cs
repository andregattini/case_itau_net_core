using CaseItau.API.DataContext.Interface;
using System.Data.SQLite;

namespace CaseItau.API.DataContext
{
    public class SqlConnection : ISqlConnection
    {
        private readonly string _connectionString;
        public SqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SQLiteConnection GetConnection()
            => new SQLiteConnection(_connectionString);
    }
}
