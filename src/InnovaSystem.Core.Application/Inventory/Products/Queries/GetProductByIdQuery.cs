using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using MediatR;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<ProductDto> { }
}
