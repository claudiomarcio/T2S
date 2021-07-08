using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovimentacaoAgg = T2S.Domain.MovimentacaoAggregate;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;
using Microsoft.EntityFrameworkCore;

namespace T2S.Infra.Data.Movimentacao
{
    public class MovimentacaoRepository : MovimentacaoAgg.IMovimentacaoRepository
    {
        private readonly T2SContext context;

        public MovimentacaoRepository(T2SContext context)
        {
            this.context = context;
        }

        public void Atualizar(MovimentacaoAgg.Movimentacao entity)
        {
            context.Set<MovimentacaoAgg.Movimentacao>().Update(entity);
        }

        public void Excluir(MovimentacaoAgg.Movimentacao entity)
        {
            context.Set<MovimentacaoAgg.Movimentacao>().Remove(entity);
        }

        public MovimentacaoAgg.Movimentacao Obter(Guid id)
        {
            return context.Set<MovimentacaoAgg.Movimentacao>().Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<IEnumerable<MovimentacaoAgg.Movimentacao>> ObterAgrupadoPorClienteETipo()
         => context.Movimentacao.Include(x=> x.Conteiner).ToList().GroupBy(x => $"{x.Conteiner.Cliente}|{x.TipoMovimentacao}").Select(x=> x.AsEnumerable());
         

        public int ObterTotalImportacoes()
          => context.Movimentacao.Include(m => m.Conteiner).ToList().Where(x=> x.Conteiner.Categoria.Descricao.Equals("Importação")).Count();

        public int ObterTotalExportacoes()
          => context.Movimentacao.Include(m => m.Conteiner).ToList().Where(x => x.Conteiner.Categoria.Descricao.Equals("Exportação")).Count();

        public void Registrar(MovimentacaoAgg.Movimentacao entity)
        {
            context.Set<MovimentacaoAgg.Movimentacao>().Add(entity);
        }

    }
}

