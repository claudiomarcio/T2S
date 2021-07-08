using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using T2S.Domain.MovimentacaoAggregate;

namespace T2S.Application.Movimentacao.Query.ObterMovimentacao
{
    public class ObterMovimentacaoQueryHandler : IRequestHandler<ObterMovimentacaoQuery, ObterMovimentacaoViewModel>
    {
        private readonly IMovimentacaoRepository movimentacaoRepository;
        private readonly IMapper mapper;

        public ObterMovimentacaoQueryHandler(IMovimentacaoRepository movimentacaoRepository, IMapper mapper)
        {
            this.movimentacaoRepository = movimentacaoRepository;
            this.mapper = mapper;
        }
        public Task<ObterMovimentacaoViewModel> Handle(ObterMovimentacaoQuery request, CancellationToken cancellationToken)
        {
            var movimentacao = movimentacaoRepository.Obter(request.Id);
            var movimentacaoViewModel = mapper.Map<ObterMovimentacaoViewModel>(movimentacao);

            return Task.FromResult(movimentacaoViewModel);
        }
    }
}
