using Feedbacks.Models;
using Feedbacks.Dto.Colaborador;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedbacks.Repositories.Colaborador;

namespace Feedbacks.Services.Colaborador
{
    public class ColaboradorService : IColaboradorInterface
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<ResponseModel<List<ColaboradorModel>>> ListarColaboradores()
        {
            var colaboradores = await _colaboradorRepository.ListarTodos();
            return new ResponseModel<List<ColaboradorModel>>(colaboradores);
        }

        public async Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorId(int idColaborador)
        {
            if (idColaborador <= 0)
            {
                return new ResponseModel<ColaboradorModel>("ID inválido");
            }

            var colaborador = await _colaboradorRepository.BuscarPorId(idColaborador);
            if (colaborador == null)
            {
                return new ResponseModel<ColaboradorModel>("Colaborador não encontrado");
            }

            return new ResponseModel<ColaboradorModel>(colaborador);
        }

        public async Task<ResponseModel<List<ColaboradorModel>>> BuscarColaboradoresPorIdProjeto(int idProjeto)
        {
            var colaboradores = await _colaboradorRepository.BuscarPorIdProjeto(idProjeto);
            return new ResponseModel<List<ColaboradorModel>>(colaboradores);
        }

        public async Task<ResponseModel<ColaboradorModel>> CriarColaborador(ColaboradorCriacaoDto colaboradorCriacaoDto)
        {
            if (colaboradorCriacaoDto == null)
            {
                return new ResponseModel<ColaboradorModel>("Colaborador não pode ser nulo");
            }

            var colaborador = new ColaboradorModel();
            colaborador.Nome = colaboradorCriacaoDto.Nome;
            colaborador.Funcao = colaboradorCriacaoDto.Funcao;
            colaborador.Prioridade = colaboradorCriacaoDto.Prioridade;
            colaborador.Data_Inicio = colaboradorCriacaoDto.Data_Inicio;
            colaborador.Data_Final = colaboradorCriacaoDto.Data_Final;

            var colaboradorCriado = await _colaboradorRepository.Criar(colaborador);
            return new ResponseModel<ColaboradorModel>(colaboradorCriado);
        }

        public async Task<ResponseModel<ColaboradorModel>> EditarColaborador(ColaboradorEdicaoDto colaboradorEdicaoDto)
        {
            if (colaboradorEdicaoDto == null)
            {
                return new ResponseModel<ColaboradorModel>("Colaborador não pode ser nulo");
            }

            var colaborador = new ColaboradorModel();
            colaborador.Nome = colaboradorEdicaoDto.Nome;
            colaborador.Funcao = colaboradorEdicaoDto.Funcao;
            colaborador.Prioridade = colaboradorEdicaoDto.Prioridade;
            colaborador.Data_Inicio = colaboradorEdicaoDto.Data_Inicio;
            colaborador.Data_Final = colaboradorEdicaoDto.Data_Final;

            var colaboradorEditado = await _colaboradorRepository.Editar(colaborador);
            return new ResponseModel<ColaboradorModel>(colaboradorEditado);
        }

        public async Task<ResponseModel<bool>> ExcluirColaborador(int idColaborador)
        {
            if (idColaborador <= 0)
            {
                return new ResponseModel<bool>("ID inválido");
            }

            var resultado = await _colaboradorRepository.Excluir(idColaborador);
            return new ResponseModel<bool>(resultado);
        }
    }
}
