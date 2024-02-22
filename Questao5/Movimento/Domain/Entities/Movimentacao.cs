namespace Movimento.Domain.Entities
{
    public class Movimentacao
    {
        public Guid Id { get; set; }

        public string IdContaCorrente { get; set; }

        public DateTime DataMovimento { get; set; }

        public string TipoMovimento { get; set; }

        public decimal Valor { get; set; }
    }
}
