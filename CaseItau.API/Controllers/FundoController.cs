using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseItau.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using CaseItau.API.Data.Repositories;

namespace CaseItau.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        private readonly IFundoRepository _fundoRepository;

        public FundoController(IFundoRepository fundoRepository)
        {
            _fundoRepository = fundoRepository;
        }
        // GET: api/Fundo
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await _fundoRepository.ListarFundos();
            return Ok(result);
        }

        [HttpGet("{codigo}", Name = "Get")]
        public async Task<IActionResult> Get(string codigo)
        {
            var result = await _fundoRepository.ListarFundoPorId(codigo);
            return Ok(result);
        }

        // POST: api/Fundo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Fundo fundo)
        {
            await _fundoRepository.InserirFundo(fundo);
            return Ok();
        }

        // PUT: api/Fundo/ITAUTESTE01
        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(string codigo, [FromBody] Fundo fundo)
        {
            await _fundoRepository.AlterarFundo(codigo, fundo);
            return Ok();
        }

        // DELETE: api/Fundo/ITAUTESTE01
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            await _fundoRepository.DeletarFundo(codigo);
            return Ok();
        }

        [HttpPut("{codigo}/patrimonio")]
        public async Task<IActionResult> MovimentarPatrimonio(string codigo, [FromBody] decimal value)
        {
            await _fundoRepository.MovimentarPatrimonio(codigo, value);
            return Ok();
        }
    }
}
