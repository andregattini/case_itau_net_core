using CaseItau.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Repository.Interface
{
    public interface IFundTypeRepository
    {
        /// <summary>
        /// List all existent types for a fund
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FundType>> ListFundTypes();
    }
}
