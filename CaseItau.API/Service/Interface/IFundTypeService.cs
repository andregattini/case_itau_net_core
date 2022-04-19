using CaseItau.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Service.Interface
{
    public interface IFundTypeService
    {
        Task<IEnumerable<FundType>> ListFundTypes();
    }
}
