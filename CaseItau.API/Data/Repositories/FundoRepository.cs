using CaseItau.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Data.Repositories
{
    public class FundoRepository : IFundoRepository
    {
        private DbSession _db;

        public FundoRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task AlterarFundo(string codigo, Fundo fundo)
        {
            using (var con = _db.Connection)
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE FUNDO SET Nome = '" + fundo.Nome + "', CNPJ = '" + fundo.Cnpj + "', CODIGO_TIPO = " + fundo.CodigoTipo + " WHERE CODIGO = '" + codigo + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                var resultado = cmd.ExecuteNonQuery();
            }
        }

        public async Task DeletarFundo(string codigo)
        {
            using (var con = _db.Connection)
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM FUNDO WHERE CODIGO = '" + codigo + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                var resultado = cmd.ExecuteNonQuery();
            }
        }

        public async Task InserirFundo(Fundo value)
        {
            using (var con = _db.Connection)
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO FUNDO VALUES('" + value.Codigo + "','" + value.Nome + "','" + value.Cnpj + "'," + value.CodigoTipo + "," + value.Patrimonio + ")";
                cmd.CommandType = System.Data.CommandType.Text;
                var resultado = cmd.ExecuteNonQuery();
            }
        }

        public async Task<Fundo> ListarFundoPorId(string codigo)
        {
            using (var con = _db.Connection)
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT F.*, T.NOME AS NOME_TIPO FROM FUNDO F INNER JOIN TIPO_FUNDO T ON T.CODIGO = F.CODIGO_TIPO WHERE F.CODIGO = '" + codigo + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var f = new Fundo();
                    f.Codigo = reader[0].ToString();
                    f.Nome = reader[1].ToString();
                    f.Cnpj = reader[2].ToString();
                    f.CodigoTipo = int.Parse(reader[3].ToString());
                    f.Patrimonio = decimal.Parse(reader[4].ToString());
                    f.NomeTipo = reader[5].ToString();
                    return f;
                }
                return null;
            }
        }

        public async Task<List<Fundo>> ListarFundos()
        {
            using (var con = _db.Connection)
            {
                var lista = new List<Fundo>();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT F.*, T.NOME AS NOME_TIPO FROM FUNDO F INNER JOIN TIPO_FUNDO T ON T.CODIGO = F.CODIGO_TIPO";
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var f = new Fundo();
                    f.Codigo = reader[0].ToString();
                    f.Nome = reader[1].ToString();
                    f.Cnpj = reader[2].ToString();
                    f.CodigoTipo = int.Parse(reader[3].ToString());
                    f.Patrimonio = decimal.Parse(reader[4].ToString());
                    f.NomeTipo = reader[5].ToString();
                    lista.Add(f);
                }
                return lista;
            }
        }

        public async Task MovimentarPatrimonio(string codigo, decimal value)
        {
            using (var con = _db.Connection)
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE FUNDO SET PATRIMONIO = IFNULL(PATRIMONIO,0) + " + value.ToString() + " WHERE CODIGO = '" + codigo + "'";
                cmd.CommandType = System.Data.CommandType.Text;
                var resultado = cmd.ExecuteNonQuery();
            }
        }
    }
}
