using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace T2S.Application.Movimentacao.Query.ObterMovimentacao
{
    public class ObterMovimentacaoQuery : IRequest<ObterMovimentacaoViewModel>
    {
        public Guid Id { get; set; }
    }
}
