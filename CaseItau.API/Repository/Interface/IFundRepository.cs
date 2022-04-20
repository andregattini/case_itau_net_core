using CaseItau.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Repository.Interface
{
    public interface IFundRepository
    {
        /// <summary>
        /// search Funds
        /// </summary>
        /// <returns>Collection of Fund</returns>
        public Task<IEnumerable<Fund>> SearchFunds(string code = null, string cnpj = null, int? type = null);
        /// <summary>
        /// Create a new fund
        /// </summary>
        /// <param name="fund">object with valid parameters</param>
        /// <returns>created fund</returns>
        public Task<Fund> CreateFund(Fund fund);
        /// <summary>
        /// Update an existent fund
        /// </summary>
        /// <param name="fund">object with valid parameters</param>
        /// <returns>updated fund</returns>
        public Task<Fund> UpdateFund(Fund fund);
        /// <summary>
        /// Delete an existent fund
        /// </summary>
        /// <param name="id">id of the fund who will be deleted</param>
        /// <returns>boolean</returns>
        public Task<bool> DeleteFund(string id);
    }
}
