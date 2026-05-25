using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using InnovaSystem.CrossCutting.Models;
using InnovaSystem.Core.Domain.Entities.Inventory;
using Microsoft.Extensions.Logging;
using InnovaSystem.Core.Application.Common.Interfaces.CQRS;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class GetProductsHandler(
        IRequestContextAccessor context,
        ILogger<GetProductsHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsDto>
    {
        private readonly IRequestContextAccessor _context = context;
        private readonly ILogger<GetProductsHandler> _logger = logger;

        public Task<Result<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductsDto();
            response.Products = new();

            // Test de excepcion
            //throw new Exception("Exception Test");

            response.Products.AddRange(new[]
            {
                new Product
                {
                    ProductId = 4,
                    ProductName = "Monitor Samsung 24",
                    ProductDescription = "Monitor LED Full HD de 24 pulgadas con entrada HDMI"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Licencia Antivirus",
                    ProductDescription = "Licencia anual de antivirus corporativo para 1 dispositivo"
                }
            });

            _logger.LogInformation("Products selected!");
            return Task.FromResult(Result<GetProductsDto>.Success(response));
        }
    }
}
