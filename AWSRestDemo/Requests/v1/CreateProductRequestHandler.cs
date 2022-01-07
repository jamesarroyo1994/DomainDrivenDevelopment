using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Entities.Products.Messages;
using Infrastructure.EventPublisher;
using Infrastructure.Repositories;
using MassTransit;
using MediatR;

namespace AWSRestDemo.Api.Requests.v1
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, bool>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IBus bus, IProductRepository repository, IMapper mapper, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        public async Task<bool> Handle(CreateProductRequest command, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Product>(command));

            var message = new ProductCreatedMessage(command.Name, command.Price);
            await _eventPublisher.Publish(message);

            return true;
        }
    }
}
