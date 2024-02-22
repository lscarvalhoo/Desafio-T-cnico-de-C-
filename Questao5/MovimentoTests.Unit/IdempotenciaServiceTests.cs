using Xunit;
using NSubstitute;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Services;

public class IdempotenciaServiceTests
{
    [Fact]
    public void RegisterFail_CallRepository()
    {
        // Arrange
        var idempotencia = new Idempotencia();
        var idempotenciaRepository = Substitute.For<IIdempotenciaRepository>();
        var idempotenciaService = new IdempotenciaService(idempotenciaRepository);

        // Act
        idempotenciaService.RegistraFalha(idempotencia);

        // Assert
        idempotenciaRepository.Received(1).RegistraFalha(idempotencia);
    }

    [Fact]
    public void RegisterFail_Success()
    {
        // Arrange
        var idempotencia = new Idempotencia();
        var idempotenciaRepository = Substitute.For<IIdempotenciaRepository>();
        idempotenciaRepository.RegistraFalha(idempotencia).Returns("Sucesso");
        var idempotenciaService = new IdempotenciaService(idempotenciaRepository);

        // Act
        var resultado = idempotenciaService.RegistraFalha(idempotencia);

        // Assert
        Assert.Equal("Sucesso", resultado);
    }
}
