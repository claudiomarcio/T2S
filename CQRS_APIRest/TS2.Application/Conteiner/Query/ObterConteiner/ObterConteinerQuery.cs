using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace T2S.Application.Conteiner.Query.ObterConteiner
{
    public class ObterConteinerQuery : IRequest<ObterConteinerViewModel>
    {
        public Guid Id { get; set; }
    }
}
