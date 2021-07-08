using System;
using System.Collections.Generic;
using MovimentacaoAgg = T2S.Domain.MovimentacaoAggregate;

namespace T2S.Application.Movimentacao.Query.ObterMovimentacaoAgrupada
{
    public class ObterMovimentacaoAgrupadaViewModel
    {
        public IEnumerable<IEnumerable<MovimentacaoAgg.Movimentacao>> Movimentacoes { get; set; }
        public int TotalImportacao { get; set; }
        public int TotalExportacao { get; set; }
    }
}
