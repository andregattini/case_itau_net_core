using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Data
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public DbSession(IConfiguration configuration)
        {
            Connection = new SQLiteConnection(configuration.GetConnectionString("DefaultConnection"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
