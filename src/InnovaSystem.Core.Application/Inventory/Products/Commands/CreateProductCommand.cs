using InnovaSystem.Core.Application.Common.Interfaces;
using InnovaSystem.Core.Domain.Entities.Inventory;

namespace InnovaSystem.Core.Application.Inventory.Products.Commands
{
    public class CreateProductCommand : ICommand<CreateProductResult>
    {
        public required Product Product { get; set; }
    }

    public class CreateProductResult()
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
