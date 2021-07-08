using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using MovimentacaoAgg = T2S.Domain.MovimentacaoAggregate;
namespace T2S.Infra.Data.Movimentacao
{
    public class MovimentacaoConfiguration : IEntityTypeConfiguration<MovimentacaoAgg.Movimentacao>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoAgg.Movimentacao> builder)
        {
            builder.ToTable("Movimentacao");
            builder.HasKey(p => p.Id);
            builder.OwnsOne(c => c.TipoMovimentacao, b => b.Property("Descricao").HasColumnName("TipoMovimentacao"));
            builder.HasOne(x => x.Conteiner).WithMany(x => x.Movimentacoes).HasForeignKey("ConteinerId");
        }
    }
}
