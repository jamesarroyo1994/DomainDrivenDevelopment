using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Products;
using Domain.Entities.Products.Messages;
using Infrastructure.EventPublisher;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;
using StackExchange.Redis;

namespace AWSRestDemo.Api.Requests.v1
{
    public class UpdateProductPriceRequestHandler : IRequestHandler<UpdateProductPriceRequest, bool>
    {
        private readonly IDatabase _cache;
        private readonly IEventPublisher _eventPublisher;
        private readonly IProductRepository _repository;

        public UpdateProductPriceRequestHandler(IProductRepository repository, IDatabase cache, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _cache = cache;
            _eventPublisher = eventPublisher;
        }

        public async Task<bool> Handle(UpdateProductPriceRequest command, CancellationToken cancellationToken)
        {
            string cachedProduct = await _cache.StringGetAsync(command.Id.ToString());
            var product = JsonSerializer.Deserialize<Product>(cachedProduct) ?? await _repository.GetAsync(command.Id);
            if (product is null) throw new NotFoundException(command.Id, nameof(product));

            product.UpdatePrice(command.Price);
            await _repository.UpdateAsync(product);

            var message = new ProductPriceUpdatedMessage(command.Id, command.Price);
            await _eventPublisher.Publish(message);

            return true;
        }
    }
}
