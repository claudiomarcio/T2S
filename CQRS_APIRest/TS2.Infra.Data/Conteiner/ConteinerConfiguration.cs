using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;

namespace T2S.Infra.Data.Conteiner
{
    public class ConteinerConfiguration : IEntityTypeConfiguration<ConteinerAgg.Conteiner>
    {
        public void Configure(EntityTypeBuilder<ConteinerAgg.Conteiner> builder)
        {            
            builder.ToTable("Conteiner");
            builder.HasKey(p => p.Id);
            builder.OwnsOne(c => c.Cliente, b => b.Property("Nome").HasColumnName("Cliente"));
            builder.OwnsOne(c => c.Tipo, b => b.Property("Value").HasColumnName("Tipo"));
            builder.OwnsOne(c => c.Status, b => b.Property("Descricao").HasColumnName("Status"));
            builder.OwnsOne(c => c.Categoria, b => b.Property("Descricao").HasColumnName("Categoria"));
            //builder.HasMany(c => c.Movimentacoes).WithOne(c => c.Conteiner);
        }
    }
}