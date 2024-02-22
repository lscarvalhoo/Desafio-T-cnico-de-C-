namespace Saldo.Domain.Entities
{
    public class SaldoConta
    {
        public int Conta { get; set; }

        public string Titular { get; set; }

        public DateTime DataReposta { get; set; }

        public decimal ValorConta { get; set; }
    }
}
