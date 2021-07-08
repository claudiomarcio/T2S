using MediatR;
using System;

namespace T2S.Application.Conteiner.Command.RegistrarConteiner
{
    public class RegistrarConteinerCommand : IRequest<bool>
    {
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public int Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
    }
}
