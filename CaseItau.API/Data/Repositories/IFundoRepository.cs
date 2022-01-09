using CaseItau.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Data.Repositories
{
    public interface IFundoRepository
    {
        Task<List<Fundo>> ListarFundos();
        Task<Fundo> ListarFundoPorId(string codigo);
        Task InserirFundo(Fundo fundo);
        Task AlterarFundo(string codigo, Fundo fundo);
        Task DeletarFundo(string codigo);
        Task MovimentarPatrimonio(string codigo, decimal value);
    }
}
