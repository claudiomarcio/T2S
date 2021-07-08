using MediatR;
using System;

namespace T2S.Domain.Core
{
    public abstract class Event : INotification
    {
        public DateTime DataOcorrencia => DateTime.Now;
    }
}
