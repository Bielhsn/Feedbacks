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
            var colaboradores = await _colaboradorRepository.ListarTodos(); // Método que você deve ter
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
            var colaboradores = await _colaboradorRepository.BuscarPorIdProjeto(idProjeto); // Implemente esse método no repositório
            return new ResponseModel<List<ColaboradorModel>>(colaboradores);
        }

        public async Task<ResponseModel<ColaboradorModel>> CriarColaborador(ColaboradorCriacaoDto colaboradorCriacaoDto)
        {
            if (colaboradorCriacaoDto == null)
            {
                return new ResponseModel<ColaboradorModel>("Colaborador não pode ser nulo");
            }

            var colaborador = new ColaboradorModel(); // Mapeie os dados do DTO para o Model aqui
            // Exemplo: colaborador.Nome = colaboradorCriacaoDto.Nome;

            var colaboradorCriado = await _colaboradorRepository.Criar(colaborador);
            return new ResponseModel<ColaboradorModel>(colaboradorCriado);
        }

        public async Task<ResponseModel<ColaboradorModel>> EditarColaborador(ColaboradorEdicaoDto colaboradorEdicaoDto)
        {
            if (colaboradorEdicaoDto == null)
            {
                return new ResponseModel<ColaboradorModel>("Colaborador não pode ser nulo");
            }

            // Implemente a lógica de edição aqui
            var colaborador = new ColaboradorModel(); // Mapeie os dados do DTO para o Model aqui
            // Exemplo: colaborador.Nome = colaboradorEdicaoDto.Nome;

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
