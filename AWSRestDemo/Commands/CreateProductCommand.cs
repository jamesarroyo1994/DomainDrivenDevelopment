using MediatR;

namespace AWSRestDemo.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
