using MediatR;
using Microsoft.AspNetCore.Mvc;
using InnovaSystem.Core.Application.Inventory.Products.Queries;

namespace InnovaSystem.WebApi.Controllers.v1.Inventory
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductById(id));
            return Ok(result);
        }
    }
}
