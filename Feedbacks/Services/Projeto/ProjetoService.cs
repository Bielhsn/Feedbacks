using Feedbacks.Models;
using Feedbacks.Repositories.Projeto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedbacks.Services.Projeto
{
    public class ProjetoService : IProjetoInterface
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task<ProjetoModel> Criar(ProjetoModel projeto)
        {
            return await _projetoRepository.Criar(projeto);
        }

        public async Task<ProjetoModel> BuscarPorId(int id)
        {
            return await _projetoRepository.BuscarPorId(id);
        }

        public async Task<List<ProjetoModel>> ListarProjetos()
        {
            return await _projetoRepository.ListarProjetos();
        }

        public async Task<ProjetoModel> Editar(ProjetoModel projeto)
        {
            return await _projetoRepository.Editar(projeto);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _projetoRepository.Excluir(id);
        }

        public async Task<ProjetoModel> BuscarProjetoPorId(int id)
        {
            return await _projetoRepository.BuscarPorId(id);
        }
    }
}
