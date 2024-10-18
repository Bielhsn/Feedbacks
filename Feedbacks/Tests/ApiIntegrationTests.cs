using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Feedbacks.Tests // Adicione um namespace específico para os testes
{
    public class ApiIntegrationTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        // Adicione seus métodos de teste aqui
    }
}