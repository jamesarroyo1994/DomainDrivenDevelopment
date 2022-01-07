using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.EventPublisher
{
    public interface IEventPublisher
    {
        Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class;
    }
}
