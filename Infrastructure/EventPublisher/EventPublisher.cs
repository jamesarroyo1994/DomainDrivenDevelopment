using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Infrastructure.EventPublisher
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IAmazonSQS _queue;

        public EventPublisher(IAmazonSQS queue)
        {
            _queue = queue;
        }

        public async Task<SendMessageResponse> Publish<T>(T message, CancellationToken cancellationToken = default) where T : SendMessageRequest
        {
            return await _queue.SendMessageAsync(message);
        }
    }
}
