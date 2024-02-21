namespace Movimento.Application.Commands.Responses
{
    public class CriarMovimentoResponse
    {
        public int StatusCode { get; set; }

        public Guid IdMovimento { get; set; }

        public string MensageErro { get; set; }
    }
}
