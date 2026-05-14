using MediatR;
using Microsoft.AspNetCore.Mvc;
using InnovaSystem.Core.Application.Inventory.Products.Queries;
using Asp.Versioning;

namespace InnovaSystem.WebApi.Controllers.v1.Inventory
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/inventory/[controller]")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HttpGet]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _mediator.Send(new GetProductByIdQuery(id));
        //    return Ok(result);
        //}

        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }
    }
}
