using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace Infrastructure.EventPublisher
{
    public interface IEventPublisher
    {
        Task<SendMessageResponse> Publish<T>(T message, CancellationToken cancellationToken = default) where T : SendMessageRequest;
    }
}
