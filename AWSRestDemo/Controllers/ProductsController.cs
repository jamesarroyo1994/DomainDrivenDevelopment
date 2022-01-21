using System.Threading.Tasks;
using AWSRestDemo.Api.Requests.v1;
using Infrastructure.Exceptions;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(request);

                    return Ok();
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }


        [HttpPut("[action]")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Price([FromBody] UpdateProductPriceRequest request)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(request);

                return Ok();
            }

            return BadRequest();
        }
    }
}
