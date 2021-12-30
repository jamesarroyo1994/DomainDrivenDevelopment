using Domain.Base;

namespace Domain.Entities.Products.Messages
{
    public class ProductCreatedMessage : BaseMessage
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductCreatedMessage(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
