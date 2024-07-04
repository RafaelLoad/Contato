using CadastroDeContatos.Application.Interfaces;
using CadastroDeContatos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly IContatoService _contato;
        public ContatoController(IContatoService contatoService)
        {
            _contato = contatoService;
        }

        [HttpGet("Consultar")]
        public async Task<IActionResult> Consultar([FromHeader] int ddd)
            => Ok(await _contato.Consultar(ddd));

        [HttpPut("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Contato contato)
            => Ok(await _contato.Atualizar(contato));

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Contato contato)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            await _contato.Cadastrar(contato);

            return Created();
        }

        [HttpDelete("Deletar")]
        public async Task<IActionResult> Deletar([FromHeader] int id)
        {
            await _contato.Deletar(id);  
            return NoContent();
        }

    }
}
