using Movimento.Application.Commands;
using Movimento.Application.Commands.Requests;
using Movimento.Application.Commands.Responses;
using Movimento.Domain.Entities;
using Movimento.Domain.Enumerators;
using Movimento.Domain.Interfaces.Services;
using NSubstitute;

namespace MovimentoTests.Unit
{
    public class MovimentoHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest()
        {
            // Arrange
            var movimentoService = Substitute.For<IMovimentoService>();
            var contaCorrenteService = Substitute.For<IContaCorrenteService>();
            var handler = new MovimentoCommandHandler(movimentoService, contaCorrenteService);

            var request = new CriarMovimentoCommand
            {
                IdContaCorrente = "1",
                DataMovimento = DateTime.Now,
                TipoMovimento = "C",
                Valor = 100
            };

            var contaCorrente = new ContaCorrente { Id = "1", Status = Status.Ativo };
            contaCorrenteService.ObterContaCorrente("1").Returns(contaCorrente);

            var expectedResponse = new CriarMovimentoResponse
            {
                StatusRequisicao = new StatusRequisicao { Code = 200 }
            };
            movimentoService.CriarMovimento(Arg.Any<Movimentacao>()).Returns(expectedResponse);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public async Task Handle_InvalidValue()
        {
            // Arrange
            var movimentoService = Substitute.For<IMovimentoService>();
            var contaCorrenteService = Substitute.For<IContaCorrenteService>();
            var handler = new MovimentoCommandHandler(movimentoService, contaCorrenteService);

            var request = new CriarMovimentoCommand
            {
                IdContaCorrente = "1",
                DataMovimento = DateTime.Now,
                TipoMovimento = "C",
                Valor = -100 // Valor negativo para causar erro
            };

            var contaCorrente = new ContaCorrente { Id = "1", Status = Status.Ativo };
            contaCorrenteService.ObterContaCorrente("1").Returns(contaCorrente);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(400, response.StatusRequisicao.Code); // Verifica se o código de erro é 400
            Assert.Equal("INVALID_VALUE", response.StatusRequisicao.MensageErro); // Verifica se a mensagem de erro é correta
        }

        [Fact]
        public async Task Handle_InvalidMovimentType()
        {
            // Arrange
            var movimentoService = Substitute.For<IMovimentoService>();
            var contaCorrenteService = Substitute.For<IContaCorrenteService>();
            var handler = new MovimentoCommandHandler(movimentoService, contaCorrenteService);

            var request = new CriarMovimentoCommand
            {
                IdContaCorrente = "1",
                DataMovimento = DateTime.Now,
                TipoMovimento = "X",
                Valor = 100 // Valor negativo para causar erro
            };

            var contaCorrente = new ContaCorrente { Id = "1", Status = Status.Ativo };
            contaCorrenteService.ObterContaCorrente("1").Returns(contaCorrente);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(400, response.StatusRequisicao.Code); // Verifica se o código de erro é 400
            Assert.Equal("INVALID_TYPE", response.StatusRequisicao.MensageErro); // Verifica se a mensagem de erro é correta
        }
    }
}
