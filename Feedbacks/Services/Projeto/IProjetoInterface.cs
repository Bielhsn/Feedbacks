using Feedbacks.Models;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Dto.Projeto;

namespace Feedbacks.Services.Projeto
{
    public interface IProjetoInterface
    {
        Task<ResponseModel<List<ProjetoModel>>> ListarProjetos();
        Task<ResponseModel<ProjetoModel>> BuscarProjetoPorId(int idProjeto);
        Task<ResponseModel<List<ProjetoModel>>> BuscarProjetoPorIdColaborador(int idColaborador);
        Task<ResponseModel<List<ProjetoModel>>> CriarProjeto(ProjetoCriacaoDto ProjetoCriacaoDto);

        Task<ResponseModel<List<ProjetoModel>>> EditarProjeto(ProjetoEdicaoDto ProjetoEdicaoDto);
        Task<ResponseModel<List<ProjetoModel>>> ExcluirProjeto(int idProjeto);
    }
}
