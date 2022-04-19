using System.Data.SQLite;

namespace CaseItau.API.DataContext.Interface
{
    public interface ISqlConnection
    {
        /// <summary>
        /// Create a new database connection
        /// </summary>
        /// <returns> instance of SQLiteConnection</returns>
        public SQLiteConnection GetConnection();
    }
}
