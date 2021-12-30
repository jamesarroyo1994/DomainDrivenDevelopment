using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
