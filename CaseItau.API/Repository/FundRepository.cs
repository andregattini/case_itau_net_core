using CaseItau.API.DataContext.Interface;
using CaseItau.API.Model.DTO;
using CaseItau.API.Repository.Interface;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Repository
{
    public class FundRepository : IFundRepository
    {
        private readonly ISqlConnection _connection;
        public FundRepository(ISqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Fund> CreateFund(Fund fund)
        {
            #region query
            string query = @"INSERT INTO FUNDO VALUES (@code, @name, @cnpj, @typeCode, @patrimony)";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new
                {
                    code = fund.Code,
                    name = fund.Name,
                    cnpj = fund.Cnpj,
                    typeCode = fund.Type.Code,
                    patrimony = fund.Patrimony
                });
                connection.Close();
                connection.Dispose();
            }
            return fund;
        }
        public async Task<bool> DeleteFund(string id)
        {
            #region query
            string query = @"DELETE FROM FUNDO WHERE CODIGO = @code";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                int rowsAffected = await connection.ExecuteAsync(query, new
                {
                    code = id,
                });
                connection.Close();
                connection.Dispose();
                return rowsAffected == 1;
            }
        }
        public async Task<Fund> GetFundById(string id)
        {
            #region query
            string query = @"SELECT 
                                    F.CODIGO        AS Code,
                                    F.NOME          AS Name,
                                    F.CNPJ          AS Cnpj,
                                    F.CODIGO_TIPO   AS CodeType,
                                    F.PATRIMONIO    AS Patrimony,
                                    ''              AS Split,
                                    TP.NOME         AS Name,
                                    TP.CODIGO       AS Code
                            FROM FUNDO F
                                INNER JOIN TIPO_FUNDO TP 
                                        ON F.CODIGO_TIPO = TP.CODIGO
                            WHERE F.CODIGO = @id";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                var fund = await connection.QueryAsync<Fund, FundType, Fund>(query, param: new { id }, map: (fund, fundType) =>
                {
                    fund.Type = fundType;
                    return fund;
                }, splitOn: "Split");
                connection.Close();
                connection.Dispose();
                return fund.FirstOrDefault();
            }
        }
        public async Task<IEnumerable<Fund>> ListFunds()
        {
            IEnumerable<Fund> funds = new List<Fund>();
            #region query
            string query = @"SELECT 
                                    F.CODIGO        AS Code,
                                    F.NOME          AS Name,
                                    F.CNPJ          AS Cnpj,
                                    F.CODIGO_TIPO   AS CodeType,
                                    F.PATRIMONIO    AS Patrimony,
                                    ''              AS Split,
                                    TP.NOME         AS Name,
                                    TP.CODIGO       AS Code
                            FROM FUNDO F
                                INNER JOIN TIPO_FUNDO TP 
                                        ON F.CODIGO_TIPO = TP.CODIGO";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                funds = await connection.QueryAsync<Fund, FundType, Fund>(query, map: (fund, fundType) =>
                {
                    fund.Type = fundType;
                    return fund;
                }, splitOn: "Split");
                connection.Close();
                connection.Dispose();
            }
            return funds;
        }
        public async Task<Fund> UpdateFund(Fund fund)
        {
            #region query
            string query = @"UPDATE FUNDO SET   NOME = @name,
                                                CNPJ = @cnpj,
                                                CODIGO_TIPO = @type,
                                                PATRIMONIO = @patrimony
                                    WHERE CODIGO = @code";
            #endregion
            using (var connection = _connection.GetConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, new
                {
                    code = fund.Code,
                    name = fund.Name,
                    cnpj = fund.Cnpj,
                    type = fund.Type.Code,
                    patrimony = fund.Patrimony
                });
                connection.Close();
                connection.Dispose();
            }
            return fund;
        }
    }
}
