using CaseItau.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Controllers
{
    [ApiController]
    public class FundTypeController : ControllerBase
    {
        private readonly IFundTypeService _fundTypeService;
        public FundTypeController(IFundTypeService fundTypeService)
        {
            _fundTypeService = fundTypeService;
        }

        [HttpGet("api/fundtypes")]
        public async Task<IActionResult> ListFundTypes()
        {
            var types = await _fundTypeService.ListFundTypes();
            if (!types?.Any() ?? true)
                return NoContent();

            return new OkObjectResult(types);
        }
    }
}
