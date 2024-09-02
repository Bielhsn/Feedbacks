using Feedbacks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Models;
using Feedbacks.Services.Colaborador;
using Feedbacks.Services.Colaborador;

namespace Feedbacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {

        private readonly IColaboradorInterface _ColaboradorInterface;
        public ColaboradorController(IColaboradorInterface ColaboradorInterface)
        {
            _ColaboradorInterface = ColaboradorInterface;
        }


        [HttpGet("ListarColaboradores")]
        public async Task<ActionResult<ResponseModel<List<ColaboradorModel>>>> ListarColaboradores()
        {
            var Colaboradores = await _ColaboradorInterface.ListarColaboradores();
            return Ok(Colaboradores);
        }

        [HttpGet("BuscarColaboradorPorId/{idColaborador}")]
        public async Task<ActionResult<ResponseModel<ColaboradorModel>>> BuscarColaboradorPorId(int idColaborador)
        {
            var Colaborador = await _ColaboradorInterface.BuscarColaboradorPorId(idColaborador);
            return Ok(Colaborador);
        }

        [HttpGet("BuscarColaboradorPorIdProjeto/{idProjeto}")]
        public async Task<ActionResult<ResponseModel<ColaboradorModel>>> BuscarColaboradorPorIdProjeto(int idProjeto)
        {
            var Colaborador = await _ColaboradorInterface.BuscarColaboradorPorIdProjeto(idProjeto);
            return Ok(Colaborador);
        }

        [HttpPost("CriarColaborador")]
        public async Task<ActionResult<ResponseModel<List<ColaboradorModel>>>> CriarColaborador(ColaboradorCriacaoDto ColaboradorCriacaoDto)
        {
            var Colaboradores = await _ColaboradorInterface.CriarColaborador(ColaboradorCriacaoDto);
            return Ok(Colaboradores);
        }


        [HttpPut("EditarColaborador")]
        public async Task<ActionResult<ResponseModel<List<ColaboradorModel>>>> EditarColaborador(ColaboradorEdicaoDto ColaboradorEdicaoDto)
        {
            var Colaboradores = await _ColaboradorInterface.EditarColaborador(ColaboradorEdicaoDto);
            return Ok(Colaboradores);
        }

        [HttpDelete("ExcluirColaborador")]
        public async Task<ActionResult<ResponseModel<List<ColaboradorModel>>>> ExcluirColaborador(int idColaborador)
        {
            var Colaboradores = await _ColaboradorInterface.ExcluirColaborador(idColaborador);
            return Ok(Colaboradores);
        }

    }
}