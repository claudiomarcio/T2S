using T2S.CrossCutting.Bus.Command;
using T2S.CrossCutting.Bus.Event;
using System.Threading.Tasks;

namespace T2S.CrossCutting.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(ICommand<T> command);
        Task RaiseEvent(IEvent @event);
    }
}
