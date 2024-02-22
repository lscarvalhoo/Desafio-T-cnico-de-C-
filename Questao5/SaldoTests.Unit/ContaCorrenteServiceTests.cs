using NSubstitute;
using Saldo.Domain.Entities;
using Saldo.Domain.Enumerators;
using Saldo.Domain.Interfaces.Repository;
using Saldo.Domain.Services;

namespace SaldoTests.Unit
{
    public class ContaCorrenteServiceTests
    {
        [Fact]
        public void Account_Valid()
        {
            // Arrange
            string id = "1";
            var contaCorrenteEsperada = new ContaCorrente { Id = id, Numero = 100, Nome = "", Status = Status.Ativo };
            var contaCorrenteRepository = Substitute.For<IContaCorrenteRepository>();
            contaCorrenteRepository.ObterConta(id).Returns(contaCorrenteEsperada);
            var contaCorrenteService = new ContaCorrenteService(contaCorrenteRepository);

            // Act
            var contaCorrenteRetornada = contaCorrenteService.ObterConta(id);

            // Assert
            Assert.Equal(contaCorrenteEsperada, contaCorrenteRetornada);
        }
    }
}