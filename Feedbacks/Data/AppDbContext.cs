using Feedbacks.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Criando as tabelas no banco
        public DbSet<ColaboradorModel> TB_Colaboradores { get; set; }
        public DbSet<ProjetoModel> TB_Projetos { get; set; }
    }
}
