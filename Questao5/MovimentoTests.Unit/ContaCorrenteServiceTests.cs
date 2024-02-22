using Movimento.Domain.Entities;
using Movimento.Domain.Enumerators;
using Movimento.Domain.Interfaces.Repositories;
using Movimento.Domain.Services;
using NSubstitute;

namespace MovimentoTests.Unit
{
    public class ContaCorrenteServiceTests
    {
        [Fact]
        public void Account_Valid()
        {
            // Arrange
            string id = "1";
            var contaCorrenteEsperada = new ContaCorrente { Id = id, Numero = 100, Nome = "" , Status = Status.Ativo}; 
            var contaCorrenteRepository = Substitute.For<IContaCorrenteRepository>();
            contaCorrenteRepository.ObterContaCorrente(id).Returns(contaCorrenteEsperada); 
            var contaCorrenteService = new ContaCorrenteService(contaCorrenteRepository);

            // Act
            var contaCorrenteRetornada = contaCorrenteService.ObterContaCorrente(id);

            // Assert
            Assert.Equal(contaCorrenteEsperada, contaCorrenteRetornada);
        } 
    }
}