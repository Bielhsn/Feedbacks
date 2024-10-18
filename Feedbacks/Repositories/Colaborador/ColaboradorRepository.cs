using Feedbacks.Data; // Namespace do contexto do banco de dados
using Feedbacks.Models; // Namespace dos modelos
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedbacks.Repositories.Colaborador // Namespace do repositório de colaboradores
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDbContext _context;

        public ColaboradorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ColaboradorModel>> ListarTodos()
        {
            // Retorna todos os colaboradores
            return await _context.TB_Colaboradores.ToListAsync();
        }

        public async Task<ColaboradorModel> BuscarPorId(int idColaborador)
        {
            // Busca um colaborador pelo ID
            return await _context.TB_Colaboradores.FindAsync(idColaborador);
        }

        public async Task<ColaboradorModel> Criar(ColaboradorModel colaborador)
        {
            // Cria um novo colaborador
            if (colaborador == null)
                return null;

            await _context.TB_Colaboradores.AddAsync(colaborador);
            await _context.SaveChangesAsync();
            return colaborador;
        }

        public async Task<ColaboradorModel> Editar(ColaboradorModel colaborador)
        {
            // Edita um colaborador existente
            var existingColaborador = await _context.TB_Colaboradores.FindAsync(colaborador.Id);
            if (existingColaborador == null)
                return null;

            existingColaborador.Nome = colaborador.Nome; // Atualize os campos conforme necessário
            existingColaborador.Funcao = colaborador.Funcao;
            existingColaborador.Prioridade = colaborador.Prioridade;
            existingColaborador.Data_Inicio = colaborador.Data_Inicio;
            existingColaborador.Data_Final = colaborador.Data_Final;

            await _context.SaveChangesAsync();
            return existingColaborador;
        }

        public async Task<bool> Excluir(int idColaborador)
        {
            // Exclui um colaborador pelo ID
            var colaborador = await _context.TB_Colaboradores.FindAsync(idColaborador);
            if (colaborador == null)
                return false;

            _context.TB_Colaboradores.Remove(colaborador);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<ColaboradorModel>> BuscarPorIdProjeto(int idProjeto)
        {
            throw new NotImplementedException();
        }
    }
}
