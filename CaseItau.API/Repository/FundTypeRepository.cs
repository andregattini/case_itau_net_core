using CaseItau.API.DataContext.Interface;
using CaseItau.API.Model.DTO;
using CaseItau.API.Repository.Interface;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Repository
{
    public class FundTypeRepository : IFundTypeRepository
    {
        private readonly ISqlConnection _connection;
        public FundTypeRepository(ISqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<FundType>> ListFundTypes()
        {
            IEnumerable<FundType> types = new List<FundType>();
            #region query
            string query = @"SELECT 
                                    TP.CODIGO       AS Code,
                                    TP.NOME         AS Name
                            FROM  TIPO_FUNDO TP ";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                types = await connection.QueryAsync<FundType>(query);
                connection.Close();
                connection.Dispose();
            }
            return types;
        }
    }
}
