using InnovaSystem.Core.Application.Inventory.Products.Commands;
using InnovaSystem.Core.Domain.Common;
using InnovaSystem.Core.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystem.Core.Application.Inventory.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<CreateProductResult>>
    {
        public Task<Result<CreateProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            CreateProductResult response = new CreateProductResult();

            if (request.Product is null)
            {
                return Task.FromResult(Result<CreateProductResult>.Failure(Error.NotFound("Producto no encontrado")));
            }

            var product = new Product()
            {
                ProductId = 1,
                ProductName = request.Product.ProductName,
                ProductDescription = request.Product.ProductDescription
            };

            response = new CreateProductResult()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CreatedAt = product.CreatedAt,                
            };

            return Task.FromResult(Result<CreateProductResult>.Success(response));
        }
    }
}
