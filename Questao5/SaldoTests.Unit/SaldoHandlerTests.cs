using Xunit;
using NSubstitute;
using Saldo.Application.Queries.Requests;
using Saldo.Domain.Entities;
using Saldo.Domain.Interfaces.Services;
using Saldo.Application.Handlers;
using Saldo.Domain.Enumerators;

public class SaldoQueryHandlerTests
{
    [Fact]
    public void Handle_ValidQuery_Erro400()
    {
        // Arrange
        var request = new ConsultaSaldoQuery { Conta = "123456" };
        var saldoEsperado = new SaldoConta { Conta = int.Parse(request.Conta), Titular = "Leo S.", DataReposta = DateTime.Now, ValorConta = 100 };
        var saldoService = Substitute.For<ISaldoService>();
        saldoService.ObterSaldo(request.Conta).Returns(saldoEsperado);
        var contaCorrenteService = Substitute.For<IContaCorrenteService>();
        var handler = new SaldoQueryHandler(saldoService, contaCorrenteService);

        // Act
        var response = handler.Handle(request, default).Result;

        // Assert
        Assert.Equal(400, response.StatusRequisicao.Code);  
    }

    [Fact]
    public void Handle_ReturnInvalidAccount()
    {
        // Arrange
        var request = new ConsultaSaldoQuery { Conta = "123456" };
        var saldoService = Substitute.For<ISaldoService>();
        saldoService.ObterSaldo(request.Conta).Returns((SaldoConta)null); 
        var contaCorrenteService = Substitute.For<IContaCorrenteService>();
        var handler = new SaldoQueryHandler(saldoService, contaCorrenteService);

        // Act
        var response = handler.Handle(request, default).Result;

        // Assert
        Assert.Equal(400, response.StatusRequisicao.Code);
        Assert.Equal("INVALID_ACCOUNT", response.StatusRequisicao.MensageErro);
        Assert.Null(response.DadosConta);
    }

    [Fact]
    public void Handle_ReturnInactiveAccount()
    {
        // Arrange
        var request = new ConsultaSaldoQuery { Conta = "123456" };
        var contaCorrente = new ContaCorrente { Numero = int.Parse(request.Conta), Status = Status.Inativo };
        var saldoService = Substitute.For<ISaldoService>();
        saldoService.ObterSaldo(request.Conta).Returns(new SaldoConta()); 
        var contaCorrenteService = Substitute.For<IContaCorrenteService>();
        contaCorrenteService.ObterConta(request.Conta).Returns(contaCorrente);
        var handler = new SaldoQueryHandler(saldoService, contaCorrenteService);

        // Act
        var response = handler.Handle(request, default).Result;

        // Assert
        Assert.Equal(400, response.StatusRequisicao.Code);
        Assert.Equal("INACTIVE_ACCOUNT", response.StatusRequisicao.MensageErro);
        Assert.Null(response.DadosConta);
    }
}
