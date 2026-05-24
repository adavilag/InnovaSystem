using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Core.Application.Inventory.Products.Commands;
using InnovaSystem.Core.Domain.Entities.Inventory;
using InnovaSystem.CrossCutting.Models;
using Microsoft.Extensions.Logging;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class CreateProductHandler(
        IRequestContextAccessor context,
        ILogger<CreateProductHandler> logger) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IRequestContextAccessor _context = context;
        private readonly ILogger<CreateProductHandler> _logger = logger;

        public Task<Result<CreateProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            CreateProductResult response = new CreateProductResult();

            if (request.Product is null)
            {
                return Task.FromResult(Result<CreateProductResult>.Failure(HttpError.NotFound("Producto no encontrado")));
            }

            var product = new Product()
            {
                ProductId = request.Product.ProductId,
                ProductName = request.Product.ProductName,
                ProductDescription = request.Product.ProductDescription
            };

            response = new CreateProductResult()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CreatedAt = product.CreatedAt,                
            };


            _logger.LogInformation("Product created successfully");

            return Task.FromResult(Result<CreateProductResult>.Success(response));
        }
    }
}
