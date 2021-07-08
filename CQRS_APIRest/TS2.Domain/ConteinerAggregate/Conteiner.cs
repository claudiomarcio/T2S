using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using T2S.Domain.Core;
using T2S.Domain.Core.Model;
using T2S.Domain.MovimentacaoAggregate;

namespace T2S.Domain.ConteinerAggregate
{
    public class Conteiner : Entity
    {
        public Cliente Cliente { get; private set; }
        public string Numero { get; private set; }
        public Tipo Tipo { get; private set; }
        public Status Status { get; private set; }
        public Categoria Categoria { get; private set; }
        public IList<Movimentacao> Movimentacoes { get; private set; }
        private Conteiner() { }

        public Conteiner(string numero)
        {
            Id = Guid.NewGuid();
            Numero = ValidarNumero(numero) ?? throw new ArgumentNullException(nameof(numero));
        }

        public Conteiner(Guid conteinerId)
        {
            Id = conteinerId;                       
        }

        public Conteiner(string cliente, string numero, int tipo, string status, string categoria)
        {
            Id = Guid.NewGuid();
            Cliente = new Cliente(cliente);
            Numero = ValidarNumero(numero) ?? throw new ArgumentNullException(nameof(numero));
            Tipo = new Tipo(tipo);
            Status = new Status(status);
            Categoria = new Categoria(categoria);            
        }

        private string ValidarNumero(string numero)
        {
            var qtdLetras = Regex.Matches(numero, @"[a-zA-Z]").Count;
            var qtdNumeros = Regex.Matches(numero, @"[0-9]").Count; 

            if (qtdLetras != 4 || qtdNumeros != 7) throw new BusinessRuleException("Campo precisar ser composto por 4 letras e 7 numeros ex: TEST1234567");

            return numero;
        }
    }
}
