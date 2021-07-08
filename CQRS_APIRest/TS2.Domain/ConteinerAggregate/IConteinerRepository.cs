using System;
using System.Linq;
using T2S.Domain.ConteinerAggregate;

namespace T2S.Domain.ConteinerAggregate
{
    public interface IConteinerRepository
    {
        Conteiner Obter(Guid id);
        void Registrar(Conteiner entity);
        void Atualizar(Conteiner entity);
        void Excluir(Conteiner entity);
    }
}
