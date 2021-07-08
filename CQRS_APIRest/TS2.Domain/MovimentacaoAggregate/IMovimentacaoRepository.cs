using System;
using System.Collections.Generic;
using System.Linq;
using T2S.Domain.MovimentacaoAggregate;

namespace T2S.Domain.MovimentacaoAggregate
{
    public interface IMovimentacaoRepository
    {
        Movimentacao Obter(Guid id);
        void Registrar(Movimentacao entity);
        void Atualizar(Movimentacao entity);
        void Excluir(Movimentacao entity);
        IEnumerable<IEnumerable<Movimentacao>> ObterAgrupadoPorClienteETipo();
        int ObterTotalImportacoes();
        int ObterTotalExportacoes();
    }
}
