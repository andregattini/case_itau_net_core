using CaseItau.API.Model;
using CaseItau.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CaseItau.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundController : ControllerBase
    {
        private readonly IFundService _fundService;
        public FundController(IFundService fundService)
        {
            _fundService = fundService;
        }
        // GET: api/Fund
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var funds = await _fundService.ListFunds();

            if (!funds?.Any() ?? true)
                return NoContent();

            return new OkObjectResult(funds);
        }

        // GET: api/Fund/ITAUTESTE01
        [HttpGet("{code}", Name = "Get")]
        public async Task<IActionResult> Get(string code)
        {
            var fund = await _fundService.GetFundById(code);

            if (fund is null)
                return NotFound();

            return new OkObjectResult(fund);
        }

        // POST: api/Fund
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fund fund)
        {
            var createdFund = await _fundService.CreateFund(fund);
            return new OkObjectResult(createdFund);
        }

        // PUT: api/Fund/ITAUTESTE01
        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] Fund fund)
        {
            var updatedFund = await _fundService.UpdateFund(fund);
            if (updatedFund is null)
                return NotFound();

            return new OkObjectResult(updatedFund);
        }

        // DELETE: api/Fund/ITAUTESTE01
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var isDeleted = await _fundService.DeleteFund(code);
            if (isDeleted)
                return Ok();

            return NotFound();
        }

        [HttpPatch("{code}/patrimony")]
        public async Task<IActionResult> MovimentarPatrimonio(string code, [FromBody] decimal patrimonyValue)
        {
            var updatedFund = await _fundService.UpdateFundPatrimony(code, patrimonyValue);

            if (updatedFund is null)
                return NotFound();

            return new OkObjectResult(updatedFund);
        }
    }
}
