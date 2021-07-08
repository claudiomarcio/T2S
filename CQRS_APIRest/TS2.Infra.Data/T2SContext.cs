using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using T2S.Domain.Core;
using System;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;
using MovimentaocaoAgg = T2S.Domain.MovimentacaoAggregate;
using T2S.Infra.Data.Conteiner;
using T2S.Infra.Data.Movimentacao;

namespace T2S.Infra.Data
{
    public class T2SContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public T2SContext(DbContextOptions<T2SContext> options) : base(options) { }
        public DbSet<ConteinerAgg.Conteiner> Conteiner { get; set; }
        public DbSet<MovimentaocaoAgg.Movimentacao> Movimentacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var conteiner = new ConteinerAgg.Conteiner
            (
               "TEST1234567"             
            );

            AdicionarConteiner(modelBuilder, conteiner, "Claudio Marcio", 40, "Cheio", "Importação");

            var movimentacao = new MovimentaocaoAgg.Movimentacao
            (                      
               dataHoraInicio: DateTime.Now,
               dataHoraFim: DateTime.Now,
               conteinerId: conteiner.Id                            
            );

            AdicionarMovimentacao(modelBuilder, movimentacao, "Embarque");

            movimentacao = new MovimentaocaoAgg.Movimentacao
            (            
              dataHoraInicio: DateTime.Now,
              dataHoraFim: DateTime.Now,
              conteinerId: conteiner.Id
            );

            AdicionarMovimentacao(modelBuilder, movimentacao, "Descarga");

            conteiner = new ConteinerAgg.Conteiner
            (
               "TEST1234568"
            );

            AdicionarConteiner(modelBuilder, conteiner, "João Luiz", 20, "Vazio", "Exportação");

            movimentacao = new MovimentaocaoAgg.Movimentacao
            (        
               dataHoraInicio: DateTime.Now,
               dataHoraFim: DateTime.Now,
               conteinerId: conteiner.Id
            );

            AdicionarMovimentacao(modelBuilder, movimentacao, "Embarque");

            movimentacao = new MovimentaocaoAgg.Movimentacao
            (             
              dataHoraInicio: DateTime.Now,
              dataHoraFim: DateTime.Now,
              conteinerId: conteiner.Id
            );

            AdicionarMovimentacao(modelBuilder, movimentacao, "Descarga");

            modelBuilder.ApplyConfiguration(new ConteinerConfiguration());
            modelBuilder.ApplyConfiguration(new MovimentacaoConfiguration());            
            modelBuilder.Ignore<Event>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlite($@"Data Source={$@"{AppDomain.CurrentDomain.BaseDirectory}\t2s.db"}");
        }

        protected void AdicionarConteiner(ModelBuilder modelBuilder, ConteinerAgg.Conteiner conteiner, string Nome, int tipo, string status, string categoria)
        {            
            modelBuilder.Entity<ConteinerAgg.Conteiner>(b =>
            {
                b.HasData(
                   conteiner
                );

                b.OwnsOne(e => e.Cliente).HasData(new
                {
                    ConteinerId = conteiner.Id,
                    Nome = Nome
                });

                b.OwnsOne(e => e.Tipo).HasData(new
                {
                    ConteinerId = conteiner.Id,
                    Value = tipo
                });

                b.OwnsOne(e => e.Status).HasData(new
                {
                    ConteinerId = conteiner.Id,
                    Descricao = status
                });

                b.OwnsOne(e => e.Categoria).HasData(new
                {
                    ConteinerId = conteiner.Id,
                    Descricao = categoria
                });
            });
          
        }
        protected void AdicionarMovimentacao
        (
            ModelBuilder modelBuilder, 
            MovimentaocaoAgg.Movimentacao movimentacao,
            string tipoMovimentacao
        )
        {          

            modelBuilder.Entity<MovimentaocaoAgg.Movimentacao>(b =>
            {
                b.HasData(new
                {
                    Id = movimentacao.Id,                   
                    DataHoraInicio = movimentacao.DataHoraInicio,
                    DataHoraFim = movimentacao.DataHoraFim,
                    ConteinerId = movimentacao.ConteinerId
                });

                b.OwnsOne(e => e.TipoMovimentacao).HasData(new
                {
                    MovimentacaoId = movimentacao.Id,
                    Descricao = tipoMovimentacao
                });
            });
        
        }        
    }
}
