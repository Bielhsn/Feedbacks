using Feedbacks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IColaboradorRepository
{
    Task<ColaboradorModel> BuscarPorId(int id);
    Task<List<ColaboradorModel>> ListarTodos();
    Task<ColaboradorModel> Criar(ColaboradorModel colaborador);
    Task<ColaboradorModel> Editar(ColaboradorModel colaborador);
    Task<bool> Excluir(int idColaborador);
    Task<List<ColaboradorModel>> BuscarPorIdProjeto(int idProjeto);
}
