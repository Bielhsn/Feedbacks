using Microsoft.AspNetCore.Mvc;
using Feedbacks.Repositories.Colaborador;
using Feedbacks.Models;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            var colaboradores = await _colaboradorRepository.ListarTodos();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColaboradorPorId(int id)
        {
            var colaborador = await _colaboradorRepository.BuscarPorId(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<IActionResult> CriarColaborador([FromBody] ColaboradorModel colaborador)
        {
            if (colaborador == null)
            {
                return BadRequest("Colaborador não pode ser nulo");
            }

            var novoColaborador = await _colaboradorRepository.Criar(colaborador);
            return CreatedAtAction(nameof(GetColaboradorPorId), new { id = novoColaborador.Id }, novoColaborador);
        }

        // Adicione outros métodos conforme necessário...
    }
}
