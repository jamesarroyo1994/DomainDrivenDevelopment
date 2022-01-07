using MediatR;

namespace AWSRestDemo.Api.Requests.v1
{
    public class UpdateProductPriceRequest : IRequest<bool>
    {
        public UpdateProductPriceRequest() {}
        public UpdateProductPriceRequest(int id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
