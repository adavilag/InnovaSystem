using InnovaSystem.Core.Application.Common.Errors;
using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Core.Application.Inventory.Products.DTOs;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using InnovaSystem.CrossCutting.Models;
using Microsoft.Extensions.Logging;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class GetProductByIdHandler(
        IRequestContextAccessor context,
        ILogger<GetProductByIdHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdDto>
    {
        private readonly IRequestContextAccessor _context = context;
        private readonly ILogger<GetProductByIdHandler> _logger = logger;

        public Task<Result<GetProductByIdDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetProductByIdDto();

            if (request.ProductId == 1)
            {
                response.product = new()
                {
                    ProductId = 1,
                    ProductName = "Laptop Dell Inspiron 15",
                    ProductDescription = "Laptop de 15 pulgadas con procesador Intel Core i7, 16GB RAM y SSD de 512GB"
                };
            }
            else if (request.ProductId == 2)
            {
                response.product = new()
                {
                    ProductId = 2,
                    ProductName = "Mouse Inalámbrico Logitech",
                    ProductDescription = "Mouse ergonómico inalámbrico con conexión Bluetooth"
                };
            }
            else
            {
                var apiError = ApiErrorCatalog.Get(ApiErrorConstants.ErrorDataNotFound);
                apiError.TechnicalErrorDescription = String.Format(apiError.TechnicalErrorDescription!, "producto", request.ProductId);
                return Task.FromResult(Result<GetProductByIdDto>.Failure(HttpError.NotFound("Producto no encontrado"), apiError));
            }

            return Task.FromResult(Result<GetProductByIdDto>.Success(response));
        }
    }
}
