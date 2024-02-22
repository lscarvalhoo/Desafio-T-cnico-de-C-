using Saldo.Domain.Enumerators;

namespace Saldo.Domain.Entities
{
    public class ContaCorrente
    {
        public string Id { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public Status Ativo { get; set; }
    }
}
