using System;

namespace T2S.Application.Movimentacao.Query.ObterMovimentacao
{
    public class ObterMovimentacaoViewModel
    {
        public Guid Id { get; set; }
        public string TipoMovimentacao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public Guid ConteinerId { get; set; }             
    }
}
