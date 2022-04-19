using CaseItau.API.Model;
using CaseItau.API.Repository.Interface;
using CaseItau.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Service
{
    public class FundService : IFundService
    {
        private readonly IFundRepository _fundRepository;
        public FundService(IFundRepository fundRepository)
        {
            _fundRepository = fundRepository;
        }

        public async Task<Fund> CreateFund(Fund fund)
        {
            var existentFund = await GetFundById(fund.Code);

            if (existentFund != null)
                return existentFund;

            return await _fundRepository.CreateFund(fund);
        }
        public async Task<bool> DeleteFund(string id)
        {
            var existentFund = await GetFundById(id);

            if (existentFund == null)
                return false;

            return await _fundRepository.DeleteFund(id);
        }
        public async Task<Fund> GetFundById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return await _fundRepository.GetFundById(id);
        }
        public async Task<IEnumerable<Fund>> ListFunds()
         => await _fundRepository.ListFunds();
        public async Task<Fund> UpdateFund(Fund fund)
        {
            var existentFund = await GetFundById(fund.Code);

            if (existentFund == null)
                return null;

            return await _fundRepository.UpdateFund(fund);
        }
        public async Task<Fund> UpdateFundPatrimony(string code, decimal patrimonyValue)
        {
            var existentFund = await GetFundById(code);

            if (existentFund == null)
                return null;

            existentFund.Patrimony += patrimonyValue;
            return await _fundRepository.UpdateFund(existentFund);
        }
    }
}
