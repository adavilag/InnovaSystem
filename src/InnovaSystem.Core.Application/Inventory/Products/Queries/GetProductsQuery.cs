using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Domain.Common;
using MediatR;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public class GetProductsQuery : IRequest<Result<GetProductsDto>> { }
}
