using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T2S.Domain.MovimentacaoAggregate;

namespace T2S.Application.Movimentacao.Query.ObterMovimentacaoAgrupada
{
    public class ObterMovimentacaoAgrupadaQueryHandler : IRequestHandler<ObterMovimentacaoAgrupadaQuery, ObterMovimentacaoAgrupadaViewModel>
    {
        private readonly IMovimentacaoRepository movimentacaoRepository;
        private readonly IMapper mapper;

        public ObterMovimentacaoAgrupadaQueryHandler(IMovimentacaoRepository movimentacaoRepository, IMapper mapper)
        {
            this.movimentacaoRepository = movimentacaoRepository;
            this.mapper = mapper;
        }
        public Task<ObterMovimentacaoAgrupadaViewModel> Handle(ObterMovimentacaoAgrupadaQuery request, CancellationToken cancellationToken)
        {
            var movimentacaoAgrupadas = movimentacaoRepository.ObterAgrupadoPorClienteETipo().ToList();
            var movimentacaoImportadas = movimentacaoRepository.ObterTotalImportacoes();
            var movimentacaoExportadas = movimentacaoRepository.ObterTotalExportacoes();

            foreach (var movimentacoes in movimentacaoAgrupadas)
            {
                foreach (var m in movimentacoes)
                {
                    m.Conteiner?.Movimentacoes.Clear();
                }
            }

            var movimentacaoViewModel = new ObterMovimentacaoAgrupadaViewModel
            {
                Movimentacoes = movimentacaoAgrupadas,
                TotalImportacao = movimentacaoImportadas,
                TotalExportacao = movimentacaoExportadas
            };

            return Task.FromResult(movimentacaoViewModel);
        }
    }
}
