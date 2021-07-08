using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.Core.Model;

namespace T2S.Domain.ConteinerAggregate
{
    public class Categoria : ValueObject<Categoria>
    {
        public string Descricao { get; }

        private Categoria() { }

        public Categoria(string descricao)
        {
            Descricao = descricao;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Descricao };
        }
    }
}