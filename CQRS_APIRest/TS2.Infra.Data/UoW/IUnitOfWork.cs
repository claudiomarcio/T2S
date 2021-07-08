using System;
using System.Collections.Generic;
using System.Text;

namespace T2S.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
