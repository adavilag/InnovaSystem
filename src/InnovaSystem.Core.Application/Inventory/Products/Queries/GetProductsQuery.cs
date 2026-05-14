using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using MediatR;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public class GetProductsQuery : IRequest<GetProductsDto> { }
}
