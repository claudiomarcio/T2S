using MediatR;
using T2S.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;

namespace T2S.Application.Conteiner.Command.RegistrarConteiner
{
    public class RegistrarConteinerCommandHandler : CommandHandler, IRequestHandler<RegistrarConteinerCommand, bool>
    {
        private readonly ConteinerAgg.IConteinerRepository conteinerRepository;

        public RegistrarConteinerCommandHandler(ConteinerAgg.IConteinerRepository conteinerRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.conteinerRepository = conteinerRepository;
        }

        public Task<bool> Handle(RegistrarConteinerCommand request, CancellationToken cancellationToken)
        {
            var conteiner = new ConteinerAgg.Conteiner(request.Cliente, request.Numero, request.Tipo, request.Status, request.Categoria);
            conteinerRepository.Registrar(conteiner);

            Commit();
            PublishEvents(conteiner.Events);

            return Task.FromResult(true);
        }
    }
}
