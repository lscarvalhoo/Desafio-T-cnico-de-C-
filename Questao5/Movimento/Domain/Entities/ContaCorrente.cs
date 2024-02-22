using Movimento.Domain.Enumerators;

namespace Movimento.Domain.Entities
{
    public class ContaCorrente
    {
        public string Id { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public Status Status { get; set; }
    }
}
