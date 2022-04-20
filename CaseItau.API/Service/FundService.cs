using CaseItau.API.Model;
using CaseItau.API.Repository.Interface;
using CaseItau.API.Service.Interface;
using System.Collections.Generic;
using System.Linq;
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
            var existentFund = await _fundRepository.SearchFunds();

            if (existentFund.Any(x => x.Code == fund.Code || x.Cnpj == fund.Cnpj))
                return null;

            return await _fundRepository.CreateFund(fund);
        }
        public async Task<bool> DeleteFund(string id)
        {
            var existentFund = await GetFundById(id);

            if (existentFund == null)
                return false;

            return await _fundRepository.DeleteFund(id);
        }
        public async Task<Fund> GetFundByCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return null;

            var funds = await _fundRepository.SearchFunds(cnpj: cnpj);
            return funds?.FirstOrDefault();
        }
        public async Task<Fund> GetFundById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var funds = await _fundRepository.SearchFunds(code: id);
            return funds?.FirstOrDefault();
        }
        public async Task<IEnumerable<Fund>> ListFunds()
         => await _fundRepository.SearchFunds();
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
