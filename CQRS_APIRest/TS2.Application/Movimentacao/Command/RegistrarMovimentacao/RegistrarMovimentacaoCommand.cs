using MediatR;
using System;

namespace T2S.Application.Movimentacao.Command.RegistrarMovimentacao
{
    public class RegistrarMovimentacaoCommand : IRequest<bool>
    {
        public int TipoMovimentacao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public Guid ConteinerId { get; set; }
    }
}
