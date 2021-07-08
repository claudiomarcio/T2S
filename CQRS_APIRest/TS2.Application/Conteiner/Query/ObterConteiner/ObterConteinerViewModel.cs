using System;
using System.Collections.Generic;
using System.Text;

namespace T2S.Application.Conteiner.Query.ObterConteiner
{
    public class ObterConteinerViewModel
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Numero { get; set; }
        public int Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
    }
}
