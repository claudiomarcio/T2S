using MediatR;

namespace T2S.CrossCutting.Bus.Command
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
