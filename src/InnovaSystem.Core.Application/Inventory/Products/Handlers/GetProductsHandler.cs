using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using InnovaSystem.Core.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
        public Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = new GetProductsDto();
            result.Products = new();

            result.Products.AddRange(new[]
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Test1",
                    ProductDescription = "Testing description 01"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Test2",
                    ProductDescription = "Testing description 02"
                }
            });

            return Task.FromResult(result);
        }
    }
}
