namespace Movimento.Domain.Entities
{
    public class Idempotencia
    {
        public Guid ChaveIdempotencia { get; set; }

        public Movimentacao Requisicao { get; set; }

        public string Resultado { get; set; }
    }
}
