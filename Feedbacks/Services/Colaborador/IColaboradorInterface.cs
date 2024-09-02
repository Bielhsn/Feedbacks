using Feedbacks.Models;
using Feedbacks.Dto.Colaborador;
using Feedbacks.Models;

namespace Feedbacks.Services.Colaborador
{
    public interface IColaboradorInterface
    {
        Task<ResponseModel<List<ColaboradorModel>>> ListarColaboradores();
        Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorId(int idColaborador);
        Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorIdProjeto(int idProjeto);
        Task<ResponseModel<List<ColaboradorModel>>> CriarColaborador(ColaboradorCriacaoDto ColaboradorCriacaoDto);

        Task<ResponseModel<List<ColaboradorModel>>> EditarColaborador(ColaboradorEdicaoDto ColaboradorEdicaoDto);
        Task<ResponseModel<List<ColaboradorModel>>> ExcluirColaborador(int idColaborador);

    }
}
