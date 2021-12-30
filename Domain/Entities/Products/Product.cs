using Domain.Base;

namespace Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
    }
}
