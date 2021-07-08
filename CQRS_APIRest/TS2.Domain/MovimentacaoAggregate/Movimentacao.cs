using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.ConteinerAggregate;
using T2S.Domain.Core.Model;

namespace T2S.Domain.MovimentacaoAggregate
{
    public class Movimentacao : Entity
    {
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime DataHoraFim { get; private set; }
        public Conteiner Conteiner { get; private set; }
        public Guid ConteinerId { get; private set; }

        private Movimentacao() { }

        public Movimentacao(DateTime dataHoraInicio, DateTime dataHoraFim, Guid conteinerId)
        {
            Id = Guid.NewGuid();          
            DataHoraInicio = dataHoraInicio.ToLocalTime();
            DataHoraFim = dataHoraFim.ToLocalTime();
            ConteinerId = conteinerId;
        }

        public Movimentacao(string tipoMovimentacao, DateTime dataHoraInicio, DateTime dataHoraFim, Guid conteinerId)
        {
            Id = Guid.NewGuid();
            TipoMovimentacao = new TipoMovimentacao(tipoMovimentacao);
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            ConteinerId = conteinerId;
        }
    }
}
