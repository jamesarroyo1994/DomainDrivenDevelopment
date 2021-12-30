using MediatR;

namespace AWSRestDemo.Commands
{
    public class UpdateProductPriceCommand : IRequest<bool>
    {
        public UpdateProductPriceCommand(int id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
