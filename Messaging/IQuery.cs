using DemoWeb.API.Shared;
using MediatR;

namespace DemoWeb.API.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
