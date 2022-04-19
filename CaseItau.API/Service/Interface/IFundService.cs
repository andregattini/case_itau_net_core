using CaseItau.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Service.Interface
{
    public interface IFundService
    {
        /// <summary>
        /// List all funds 
        /// </summary>
        /// <returns>Collection of fund</returns>
        Task<IEnumerable<Fund>> ListFunds();
        /// <summary>
        /// Get an fund by id
        /// </summary>
        /// <returns>object of fund</returns>
        Task<Fund> GetFundById(string id);
        /// <summary>
        /// Create a new fund
        /// </summary>
        /// <returns>created fund</returns>
        Task<Fund> CreateFund(Fund fund);
        /// <summary>
        /// delete an existent fund
        /// </summary>
        /// <returns>deleted status</returns>
        Task<bool> DeleteFund(string id);
        /// <summary>
        /// update fund information
        /// </summary>
        /// <returns> updated fund</returns>
        Task<Fund> UpdateFund(Fund fund);
        /// <summary>
        /// update the fund patrimony
        /// </summary>
        /// <returns>fund with new patrimony</returns>
        Task<Fund> UpdateFundPatrimony(string code, decimal patrimonyValue);
    }
}
