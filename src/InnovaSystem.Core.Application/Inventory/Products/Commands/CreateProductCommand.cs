using InnovaSystem.Core.Domain.Common;
using InnovaSystem.Core.Domain.Entities.Inventory;
using MediatR;

namespace InnovaSystem.Core.Application.Inventory.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<CreateProductResult>>
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
