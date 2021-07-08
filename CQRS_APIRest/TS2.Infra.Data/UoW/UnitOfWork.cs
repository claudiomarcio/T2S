using System;

namespace T2S.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly T2SContext t2sContexto;

        public UnitOfWork(T2SContext context)
        {
            t2sContexto = context;
        }

        public bool Commit()
        {
            return t2sContexto.SaveChanges() > 0;
        }

        public void Dispose()
        {
            t2sContexto.Dispose();
        }
    }
}
