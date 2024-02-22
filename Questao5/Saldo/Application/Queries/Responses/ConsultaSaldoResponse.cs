namespace Saldo.Application.Queries.Responses
{
    public class ConsultaSaldoResponse
    {
        public DadosConta DadosConta { get; set; }

        public StatusRequisicao StatusRequisicao { get; set; }
    }

    public class DadosConta
    {
        public int Conta { get; set; }

        public string Titular { get; set; }

        public DateTime DataReposta { get; set; }

        public decimal ValorConta { get; set; }
    }


    public class StatusRequisicao
    {
        public int Code { get; set; }

        public string MensageErro { get; set; }
    }
}
