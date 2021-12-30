using AutoMapper;
using Domain.Entities.Products;
using Domain.Entities.Products.Messages;
using Infrastructure.Repositories;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AWSRestDemo.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IBus _bus;
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IBus bus, IProductRepository repository, IMapper mapper)
        {
            _bus = bus;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Product>(command));

            var message = new ProductCreatedMessage(command.Name, command.Price);
            await _bus.Publish(message);

            return true;
        }
    }
}
