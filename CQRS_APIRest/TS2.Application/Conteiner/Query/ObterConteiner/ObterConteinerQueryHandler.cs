using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using T2S.Application.Conteiner.Query.ObterConteiner;
using T2S.Domain.ConteinerAggregate;

namespace T2S.Application.Container.Query.ObterConteiner
{
    public class ObterConteinerQueryHandler : IRequestHandler<ObterConteinerQuery, ObterConteinerViewModel>
    {
        private readonly IConteinerRepository containerRepository;
        private readonly IMapper mapper;

        public ObterConteinerQueryHandler(IConteinerRepository containerRepository, IMapper mapper)
        {
            this.containerRepository = containerRepository;
            this.mapper = mapper;
        }
        public Task<ObterConteinerViewModel> Handle(ObterConteinerQuery request, CancellationToken cancellationToken)
        {
            var conteiner = containerRepository.Obter(request.Id);
            var conteinerViewModel = mapper.Map<ObterConteinerViewModel>(conteiner);

            return Task.FromResult(conteinerViewModel);
        }
    }
}
