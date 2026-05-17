using InnovaSystem.Core.Application.Common.Interfaces;
using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using InnovaSystem.Core.Domain.Common;
using InnovaSystem.Core.Domain.Entities.Inventory;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class GetProductsHandler(ILogger<GetProductsHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsDto>
    {
        private readonly ILogger<GetProductsHandler> _logger = logger;

        public Task<Result<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductsDto();
            response.Products = new();

            response.Products.AddRange(new[]
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

            _logger.LogInformation("Products selected!");
            return Task.FromResult(Result<GetProductsDto>.Success(response));
        }
    }
}
