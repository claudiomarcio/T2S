using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.Core.Model;

namespace T2S.Domain.MovimentacaoAggregate
{
    public class TipoMovimentacao : ValueObject<TipoMovimentacao>
    {
        public string Descricao { get; }

        private TipoMovimentacao() { }

        public TipoMovimentacao(string descricao)
        {
            Descricao = descricao;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Descricao };
        }
    }
}