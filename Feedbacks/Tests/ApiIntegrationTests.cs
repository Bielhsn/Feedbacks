using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Feedbacks.Tests
{
    public class ApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Colaboradores_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/Colaborador/ListarColaboradores");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task Get_ProjetoById_ReturnsOk()
        {
            // Arrange
            var client = _factory.CreateClient();
            int projetoId = 1; // ID válido de teste

            // Act
            var response = await client.GetAsync($"/api/Projeto/BuscarProjetoId/{projetoId}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task Post_CriarColaborador_ReturnsCreated()
        {
            // Arrange
            var client = _factory.CreateClient();
            var novoColaborador = new
            {
                Nome = "Teste Colaborador",
                Funcao = "Desenvolvedor",
                Prioridade = 1,
                DataInicio = "2024-10-01",
                DataFinal = "2024-12-31"
            };

            // Act
            var response = await client.PostAsJsonAsync("/api/Colaborador/CriarColaborador", novoColaborador);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Put_EditarColaborador_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.CreateClient();
            var colaboradorAtualizado = new
            {
                Id = 1, // ID de um colaborador existente
                Nome = "Colaborador Atualizado",
                Funcao = "Arquiteto",
                Prioridade = 2,
                DataInicio = "2024-11-01",
                DataFinal = "2025-01-01"
            };

            // Act
            var response = await client.PutAsJsonAsync("/api/Colaborador/EditarColaborador", colaboradorAtualizado);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_ExcluirColaborador_ReturnsNoContent()
        {
            // Arrange
            var client = _factory.CreateClient();
            int colaboradorId = 1; //ID de um colaborador existente para teste

            // Act
            var response = await client.DeleteAsync($"/api/Colaborador/ExcluirColaborador/{colaboradorId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
