using Xunit;
using NSubstitute;
using Movimento.Domain.Services;
using Movimento.Domain.Entities;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Application.Commands.Responses;

public class MovimentoServiceTests
{
    [Fact]
    public void CriarMovimento_DeveChamarMetodoCorretoDoRepositorio()
    {
        // Arrange
        var movimentacao = new Movimentacao();
        var movimentoRepository = Substitute.For<IMovimentoRepository>();
        var movimentoService = new MovimentoService(movimentoRepository);

        // Act
        movimentoService.CriarMovimento(movimentacao);

        // Assert
        movimentoRepository.Received(1).NovoMovimento(movimentacao);
    }

    [Fact]
    public void CriarMovimento_DeveRetornarRespostaCorreta()
    {
        // Arrange
        var movimentacao = new Movimentacao();
        var criarMovimentoResponseEsperada = new CriarMovimentoResponse();
        var movimentoRepository = Substitute.For<IMovimentoRepository>();
        movimentoRepository.NovoMovimento(movimentacao).Returns(criarMovimentoResponseEsperada);
        var movimentoService = new MovimentoService(movimentoRepository);

        // Act
        var resultado = movimentoService.CriarMovimento(movimentacao);

        // Assert
        Assert.Same(criarMovimentoResponseEsperada, resultado);
    }
}
