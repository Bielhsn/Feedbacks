using Feedbacks.Data;
using Feedbacks.Repositories.Colaborador;
using Feedbacks.Repositories.Projeto;
using Feedbacks.Services.Colaborador;
using Feedbacks.Services.Projeto;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks // Adicione um namespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Registrando serviços e repositórios
            builder.Services.AddScoped<IColaboradorInterface, ColaboradorService>();
            builder.Services.AddScoped<IProjetoInterface, ProjetoService>();
            builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
            builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

            // Configurando o DbContext para usar Oracle
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Configurando o HttpClient para chamadas a APIs externas
            builder.Services.AddHttpClient<ExternalApiService>(client =>
            {
                client.BaseAddress = new Uri("https://external-api-url.com");
            });

            var app = builder.Build();

            // Configuração do middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Para desenvolvimento, exibe erros detalhados
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
