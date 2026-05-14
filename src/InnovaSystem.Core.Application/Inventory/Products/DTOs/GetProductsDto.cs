using InnovaSystem.Core.Domain.Entities.Inventory;

namespace InnovaSystem.Core.Application.Inventory.Products.DTOs
{
    public class GetProductsDto
    {
        public List<Product>? Products { get; set; }
    }
}
