using Domain.Entities.Products;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {

    }
}
