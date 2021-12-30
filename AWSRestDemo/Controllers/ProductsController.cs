using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Infrastructure.Exceptions;
using MassTransit.Mediator;
using AWSRestDemo.Commands;

namespace AWSRestDemo.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);

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
        public async Task<IActionResult> UpdatePrice([FromBody] UpdateProductPriceCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);

                return Ok();
            }

            return BadRequest();
        }
    }
}
