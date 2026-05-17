using MediatR;
using Microsoft.AspNetCore.Mvc;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using Asp.Versioning;
using InnovaSystem.Core.Application.Inventory.Products.Commands;

namespace InnovaSystem.WebApi.Controllers.v1.Inventory
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/inventory/[controller]")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
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
