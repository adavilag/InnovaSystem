using InnovaSystem.Core.Application.Common.Interfaces.Repositories;
using InnovaSystem.Core.Domain.Entities.Inventory;

namespace InnovaSystem.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
