using Xunit;
using NSubstitute;
using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Repository;
using Saldo.Domain.Services;

public class SaldoServiceTests
{
    [Fact]
    public void Balance_CallCorrectMethod()
    {
        // Arrange
        string numeroConta = "123456";
        var saldoRepository = Substitute.For<ISaldoRepository>();
        var saldoService = new SaldoService(saldoRepository);

        // Act
        saldoService.ObterSaldo(numeroConta);

        // Assert
        saldoRepository.Received(1).ObterSaldo(numeroConta);
    }

    [Fact]
    public void Balance_ReturnBalance()
    {
        // Arrange
        int numeroConta = 123456;
        decimal valor = 1000;
        var saldoEsperado = new SaldoConta { Conta = numeroConta, ValorConta = valor };
        var saldoRepository = Substitute.For<ISaldoRepository>();
        saldoRepository.ObterSaldo(numeroConta.ToString()).Returns(saldoEsperado);
        var saldoService = new SaldoService(saldoRepository);

        // Act
        var resultado = saldoService.ObterSaldo(numeroConta.ToString());

        // Assert
        Assert.Equal(saldoEsperado, resultado);
    }
}
