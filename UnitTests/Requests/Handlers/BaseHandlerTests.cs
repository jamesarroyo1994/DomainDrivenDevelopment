using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;

namespace UnitTests.Requests.Handlers
{
    public abstract class BaseHandlerTests<TRequest, TResponse, THandler> where TRequest : IRequest<TResponse>, new() 
                                                                          where THandler : IRequestHandler<TRequest, TResponse>
    {
        public async Task GivenRequest_ShouldInvokeHandler()
        {
            var mediator = new Mock<IMediator>();
            var request = new TRequest();

            await mediator.Object.Send(request);

            mediator
                .Setup(m => m.Send(It.IsAny<TRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null);

            mediator.Verify(x => x.Send(It.IsAny<THandler>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
