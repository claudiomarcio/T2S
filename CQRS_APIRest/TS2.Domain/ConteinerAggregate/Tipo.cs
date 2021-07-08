using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.Core.Model;

namespace T2S.Domain.ConteinerAggregate
{
    public class Tipo : ValueObject<Cliente>
    {
        public int Value { get; }

        private Tipo() { }

        public Tipo(int value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Value };
        }
    }
}
