using Domain.Base;

namespace Domain.Entities.Products.Messages
{
    public class ProductPriceUpdatedMessage : BaseMessage
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public ProductPriceUpdatedMessage(int id, decimal price)
        {
            Id = id;
            Price = price;
        }
    }
}
