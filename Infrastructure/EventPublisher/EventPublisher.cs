using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace Infrastructure.EventPublisher
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IBus _bus;

        public EventPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class
        {
            await _bus.Publish(message);
        }
    }
}
