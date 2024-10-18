using Feedbacks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedbacks.Repositories.Projeto
{
    public interface IProjetoRepository
    {
        Task<ProjetoModel> Criar(ProjetoModel projeto);
        Task<ProjetoModel> BuscarPorId(int id);
        Task<List<ProjetoModel>> ListarProjetos();
        Task<ProjetoModel> Editar(ProjetoModel projeto);
        Task<bool> Excluir(int id);
        Task<List<ProjetoModel>> BuscarPorIdColaborador(int colaboradorId); // Método para buscar por ID do colaborador
    }
}
