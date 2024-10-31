using Feedbacks.Data;
using Feedbacks.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedbacks.Repositories.Projeto
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProjetoModel> Criar(ProjetoModel projeto)
        {
            await _context.TB_Projetos.AddAsync(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<ProjetoModel> BuscarPorId(int id)
        {
            return await _context.TB_Projetos.FindAsync(id);
        }

        public async Task<List<ProjetoModel>> ListarProjetos()
        {
            return await _context.TB_Projetos.ToListAsync();
        }

        public async Task<ProjetoModel> Editar(ProjetoModel projeto)
        {
            _context.TB_Projetos.Update(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<bool> Excluir(int id)
        {
            var projeto = await BuscarPorId(id);
            if (projeto == null) return false;

            _context.TB_Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjetoModel>> BuscarPorIdColaborador(int colaboradorId)
        {
            return await _context.TB_Projetos
                .Where(p => p.Colaborador.Id == colaboradorId)
                .ToListAsync();
        }
    }
}
