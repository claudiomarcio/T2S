using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.Core.Model;

namespace T2S.Domain.ConteinerAggregate
{
    public class Cliente : ValueObject<Cliente>
    {
        public string Nome { get; }

        private Cliente() { }

        public Cliente(string nome)
        {           
            Nome = nome;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Nome };
        }
    }
}