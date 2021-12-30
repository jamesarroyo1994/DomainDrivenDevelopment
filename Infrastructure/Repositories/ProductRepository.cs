using Domain.Entities.Products;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
    }
}
