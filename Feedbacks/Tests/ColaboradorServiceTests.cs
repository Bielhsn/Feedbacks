using Moq;
using Xunit;
using Feedbacks.Services.Colaborador;
using Feedbacks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedbacks.Repositories.Colaborador;

public class ColaboradorServiceTests
{
    private readonly ColaboradorService _service;
    private readonly Mock<IColaboradorRepository> _mockRepository;

    public ColaboradorServiceTests()
    {
        // Criar o mock do repositório
        _mockRepository = new Mock<IColaboradorRepository>();

        // Inicializar o serviço com o repositório mockado
        _service = new ColaboradorService(_mockRepository.Object);
    }

    [Fact]
    public async Task BuscarColaboradorPorId_ReturnsColaborador_WhenExists()
    {
        // Arrange
        var colaborador = new ColaboradorModel { Id = 1, Nome = "Colaborador Teste" };
        _mockRepository.Setup(m => m.BuscarPorId(1)).ReturnsAsync(colaborador);

        // Act
        var result = await _service.BuscarColaboradorPorId(1);

        // Assert
        Assert.NotNull(result.Dados);
        Assert.Equal("Colaborador Localizado!", result.Mensagem);
    }

    [Fact]
    public async Task BuscarColaboradorPorId_ReturnsNotFound_WhenDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(m => m.BuscarPorId(It.IsAny<int>())).ReturnsAsync((ColaboradorModel)null);

        // Act
        var result = await _service.BuscarColaboradorPorId(1);

        // Assert
        Assert.Null(result.Dados);
        Assert.Equal("Colaborador não encontrado", result.Mensagem);
    }
}
