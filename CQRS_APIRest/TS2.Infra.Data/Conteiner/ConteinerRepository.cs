using System;
using System.Linq;
using ConteinerAgg = T2S.Domain.ConteinerAggregate;

namespace T2S.Infra.Data.Conteiner
{
    public class ConteinerRepository : ConteinerAgg.IConteinerRepository
    {
        private readonly T2SContext context;

        public ConteinerRepository(T2SContext context)
        {
            this.context = context;
        }       
        public void Atualizar(ConteinerAgg.Conteiner entity)
        {
            context.Set<ConteinerAgg.Conteiner>().Update(entity);
        }
        
        public void Excluir(ConteinerAgg.Conteiner entity)
        {
            context.Set<ConteinerAgg.Conteiner>().Remove(entity);
        }
    
        public ConteinerAgg.Conteiner Obter(Guid id)
        {
            return context.Set<ConteinerAgg.Conteiner>().Where(c => c.Id == id).FirstOrDefault();
        }

        public void Registrar(ConteinerAgg.Conteiner entity)
        {
            context.Set<ConteinerAgg.Conteiner>().Add(entity);
        }      
    }
}

