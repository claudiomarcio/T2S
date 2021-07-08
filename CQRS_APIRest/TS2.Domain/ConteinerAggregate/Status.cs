using System;
using System.Collections.Generic;
using System.Text;
using T2S.Domain.Core.Model;

namespace T2S.Domain.ConteinerAggregate
{
    public class Status : ValueObject<Status>
    {
        public string Descricao { get; }

        private Status() { }

        public Status(string descricao)
        {
            Descricao = descricao;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Descricao };
        }
    }
}
