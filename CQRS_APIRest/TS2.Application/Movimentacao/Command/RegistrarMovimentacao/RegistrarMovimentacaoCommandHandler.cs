using MediatR;
using T2S.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using MovimentacaoAgg = T2S.Domain.MovimentacaoAggregate;

namespace T2S.Application.Movimentacao.Command.RegistrarMovimentacao
{
    public class RegistrarMovimentacaoCommandHandler : CommandHandler, IRequestHandler<RegistrarMovimentacaoCommand, bool>
    {
        private readonly MovimentacaoAgg.IMovimentacaoRepository movimentacaoRepository;

        public RegistrarMovimentacaoCommandHandler(MovimentacaoAgg.IMovimentacaoRepository movimentacaoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.movimentacaoRepository = movimentacaoRepository;
        }

        public Task<bool> Handle(RegistrarMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            var movimentacao = new MovimentacaoAgg.Movimentacao(request.TipoMovimentacao.ToString(), request.DataHoraInicio, request.DataHoraFim, request.ConteinerId);
            movimentacaoRepository.Registrar(movimentacao);

            Commit();
            PublishEvents(movimentacao.Events);

            return Task.FromResult(true);
        }
    }
}
