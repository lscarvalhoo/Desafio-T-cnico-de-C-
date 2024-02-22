namespace Movimento.Application.Commands.Responses
{
    public class CriarMovimentoResponse
    { 
        public Guid IdMovimento { get; set; }
        public StatusRequisicao StatusRequisicao { get; set; }

    }

    public class StatusRequisicao
    {
        public int Code { get; set; }  
        public string MensageErro { get; set; } 
    }
}
