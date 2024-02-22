namespace Saldo.Application.Queries.Responses
{
    public class ConsultaSaldoResponse
    {
        public int Conta { get; set; }

        public string Titular { get; set; }

        public DateTime DataReposta { get; set; }

        public decimal ValorConta { get; set; }
    }
}
