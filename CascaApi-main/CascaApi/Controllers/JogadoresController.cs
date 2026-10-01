using CascaApi.Models;
using CascaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CascaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController(IJogadorRepository repository) : ControllerBase
    {
        [HttpPost]
        public ActionResult<JogadorModel> Cadastrar([FromBody] JogadorModel jogador)
        {
            if (!repository.Adicionar(jogador))
                return Conflict(new { mensagem = "Ja existe um jogador cadastrado com este CPF." });

            return CreatedAtAction(nameof(Listar), routeValues: null, value: jogador);
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<JogadorModel>> Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("peneira")]
        public ActionResult<IReadOnlyCollection<JogadorModel>> ListarNaPeneira()
        {
            return Ok(repository.ListarNaPeneira());
        }

        [HttpPatch("{cpf}/aprovacao")]
        public IActionResult AtualizarAprovacao(string cpf, [FromBody] bool aprovado)
        {
            if (!repository.AtualizarAprovacao(cpf, aprovado))
                return NotFound(new { mensagem = "Jogador nao encontrado." });

            return NoContent();
        }
    }
}
