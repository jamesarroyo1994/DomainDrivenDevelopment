using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AWSRestDemo.Api.Requests.v1;
using Infrastructure.Exceptions;
using MassTransit.Mediator;

namespace AWSRestDemo.Controllers
{
    [Route("api/{version:apiVersion}/[controller]")]
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


        [HttpPut("[action]/{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdatePrice([FromBody] UpdateProductPriceRequest request)
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
