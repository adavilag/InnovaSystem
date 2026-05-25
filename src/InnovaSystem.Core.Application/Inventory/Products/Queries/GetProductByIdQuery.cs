using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Core.Application.Inventory.Products.DTOs;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public record GetProductByIdQuery(int ProductId) : IQuery<GetProductByIdDto> { }
}
