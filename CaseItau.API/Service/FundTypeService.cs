using CaseItau.API.Model.DTO;
using CaseItau.API.Repository.Interface;
using CaseItau.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Service
{
    public class FundTypeService : IFundTypeService
    {
        private readonly IFundTypeRepository _fundTypeRepository;
        public FundTypeService(IFundTypeRepository fundTypeRepository)
        {
            _fundTypeRepository = fundTypeRepository;
        }
        public async Task<IEnumerable<FundType>> ListFundTypes()
            => await _fundTypeRepository.ListFundTypes();
    }
}
