using Feedbacks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedbacks.Services.Projeto
{
    public interface IProjetoInterface
    {
        Task<ProjetoModel> Criar(ProjetoModel projeto);
        Task<ProjetoModel> BuscarPorId(int id);
        Task<List<ProjetoModel>> ListarProjetos();
        Task<ProjetoModel> Editar(ProjetoModel projeto);
        Task<bool> Excluir(int id);
        Task<ProjetoModel> BuscarProjetoPorId(int id);
    }
}
