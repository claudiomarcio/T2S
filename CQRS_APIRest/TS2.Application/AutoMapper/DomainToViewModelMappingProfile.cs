using AutoMapper;
using T2S.Application.Conteiner.Query.ObterConteiner;
using T2S.Application.Movimentacao.Query.ObterMovimentacao;
using T2S.Application.Movimentacao.Query.ObterMovimentacaoAgrupada;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;
using MovimentacaoAgg = T2S.Domain.MovimentacaoAggregate;

namespace T2S.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ConteinerAgg.Conteiner, ObterConteinerViewModel>()
                .ForMember(d => d.Cliente, o => o.MapFrom(src => src.Cliente.Nome))
                .ForMember(d => d.Tipo, o => o.MapFrom(src => src.Tipo.Value));

            CreateMap<MovimentacaoAgg.Movimentacao, ObterMovimentacaoViewModel>();
         
        }
    }
}
