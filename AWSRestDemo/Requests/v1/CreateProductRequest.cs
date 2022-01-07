using MediatR;

namespace AWSRestDemo.Api.Requests.v1
{
    public class CreateProductRequest : IRequest<bool>
    {
        public CreateProductRequest() {}
        public CreateProductRequest(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
