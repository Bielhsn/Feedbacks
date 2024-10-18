using Feedbacks.Models;
using Feedbacks.Dto.Colaborador; // Supondo que você tenha esses DTOs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedbacks.Services.Colaborador
{
    public interface IColaboradorInterface
    {
        Task<ResponseModel<List<ColaboradorModel>>> ListarColaboradores();
        Task<ResponseModel<ColaboradorModel>> BuscarColaboradorPorId(int idColaborador);
        Task<ResponseModel<List<ColaboradorModel>>> BuscarColaboradoresPorIdProjeto(int idProjeto); // Ajustado para corresponder ao método
        Task<ResponseModel<ColaboradorModel>> CriarColaborador(ColaboradorCriacaoDto colaboradorCriacaoDto); // Retorno de ColaboradorModel
        Task<ResponseModel<ColaboradorModel>> EditarColaborador(ColaboradorEdicaoDto colaboradorEdicaoDto); // Retorno de ColaboradorModel
        Task<ResponseModel<bool>> ExcluirColaborador(int idColaborador); // Retorno de bool para indicar sucesso
    }
}
