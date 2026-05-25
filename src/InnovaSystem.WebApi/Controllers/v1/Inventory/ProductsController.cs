using Asp.Versioning;
using InnovaSystem.Core.Application.Common.Models;
using InnovaSystem.Core.Application.Inventory.Products.Commands;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using InnovaSystem.Core.Application.Common.Interfaces.CQRS;

namespace InnovaSystem.WebApi.Controllers.v1.Inventory
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/inventory/[controller]")]
    public class ProductsController(
        IRequestContextAccessor requestContextAccesor,
        IMediator mediator,
        ILogger<ProductsController> logger) : ApiControllerBase(requestContextAccesor)
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<ProductsController> _logger = logger;

        [HttpGet()]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting Products...!");
            var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting Product By Id: {ProductId}", id);
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken); 
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateProductCommand request,
            CancellationToken cancellationToken
            )
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
