using CaseItau.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Repository.Interface
{
    public interface IFundRepository
    {
        /// <summary>
        /// List all existents funds
        /// </summary>
        /// <returns>Collection of Fund</returns>
        public Task<IEnumerable<Fund>> ListFunds();
        /// <summary>
        /// search a fund by id
        /// </summary>
        /// <param name="id">code property</param>
        /// <returns>fund object</returns>
        public Task<Fund> GetFundById(string id);
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
