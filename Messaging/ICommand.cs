using DemoWeb.API.Shared;
using MediatR;

namespace DemoWeb.API.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
