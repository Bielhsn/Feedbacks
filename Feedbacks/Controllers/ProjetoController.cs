using Feedbacks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Dto.Projeto;
using Feedbacks.Services.Colaborador;
using Feedbacks.Services.Projeto;

namespace Feedbacks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoInterface _projetoService;

        public ProjetoController(IProjetoInterface projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjeto(int id)
        {
            var projeto = await _projetoService.BuscarProjetoPorId(id);

            if (projeto == null)
            {
                return NotFound("Projeto não encontrado");
            }

            return Ok(projeto);
        }
    }

}