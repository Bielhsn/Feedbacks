using Feedbacks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Dto.Projeto;
using Feedbacks.Services.Colaborador;
using Feedbacks.Services.Projeto;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoInterface _ProjetoInterface;
        public ProjetoController(IProjetoInterface ProjetoInterface)
        {
            _ProjetoInterface = ProjetoInterface;
        }


        [HttpGet("ListarProjetos")]
        public async Task<ActionResult<ResponseModel<List<ProjetoModel>>>> ListarProjetos()
        {
            var Projetos = await _ProjetoInterface.ListarProjetos();
            return Ok(Projetos);
        }

        [HttpGet("BuscarProjetoPorId/{idProjeto}")]
        public async Task<ActionResult<ResponseModel<ProjetoModel>>> BuscarProjetoPorId(int idProjeto)
        {
            var Projeto = await _ProjetoInterface.BuscarProjetoPorId(idProjeto);
            return Ok(Projeto);
        }

        [HttpGet("BuscarProjetoPorIdColaborador/{idColaborador}")]
        public async Task<ActionResult<ResponseModel<ProjetoModel>>> BuscarProjetoPorIdColaborador(int idColaborador)
        {
            var Projeto = await _ProjetoInterface.BuscarProjetoPorIdColaborador(idColaborador);
            return Ok(Projeto);
        }

        [HttpPost("CriarProjeto")]
        public async Task<ActionResult<ResponseModel<List<ProjetoModel>>>> CriarProjeto(ProjetoCriacaoDto ProjetoCriacaoDto)
        {
            var Projetos = await _ProjetoInterface.CriarProjeto(ProjetoCriacaoDto);
            return Ok(Projetos);
        }


        [HttpPut("EditarProjeto")]
        public async Task<ActionResult<ResponseModel<List<ProjetoModel>>>> EditarProjeto(ProjetoEdicaoDto ProjetoEdicaoDto)
        {
            var Projetos = await _ProjetoInterface.EditarProjeto(ProjetoEdicaoDto);
            return Ok(Projetos);
        }

        [HttpDelete("ExcluirProjeto")]
        public async Task<ActionResult<ResponseModel<List<ColaboradorModel>>>> ExcluirProjeto(int idProjeto)
        {
            var Projetos = await _ProjetoInterface.ExcluirProjeto(idProjeto);
            return Ok(Projetos);
        }
    }
}