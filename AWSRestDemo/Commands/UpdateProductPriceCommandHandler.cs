using Domain.Entities.Products;
using Domain.Entities.Products.Messages;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MassTransit;
using MediatR;
using StackExchange.Redis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AWSRestDemo.Commands
{
    public class UpdateProductPriceCommandHandler : IRequestHandler<UpdateProductPriceCommand, bool>
    {
        private readonly IBus _bus;
        private readonly IDatabase _cache;
        private readonly IProductRepository _repository;

        public UpdateProductPriceCommandHandler(IBus bus, IProductRepository repository, IDatabase cache)
        {
            _bus = bus;
            _repository = repository;
            _cache = cache;
        }

        public async Task<bool> Handle(UpdateProductPriceCommand command, CancellationToken cancellationToken)
        {
            string cachedProduct = await _cache.StringGetAsync(command.Id.ToString());
            var product = JsonSerializer.Deserialize<Product>(cachedProduct) ?? await _repository.GetAsync(command.Id);
            if (product is null) throw new NotFoundException(command.Id, nameof(product));

            product.UpdatePrice(command.Price);
            await _repository.UpdateAsync(product);

            var message = new ProductPriceUpdatedMessage(command.Id, command.Price);
            await _bus.Publish(message);

            return true;
        }
    }
}
