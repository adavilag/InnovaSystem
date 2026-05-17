using InnovaSystem.Core.Application.Common.Interfaces;
using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Domain.Common;
using MediatR;

namespace InnovaSystem.Core.Application.Inventory.Products.Queries
{
    public class GetProductsQuery : IQuery<GetProductsDto> { }
}
