using System.Threading.Tasks;
using Api.Requests.v1;
using AWSRestDemo.Api.Requests.v1;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Get(int orderId)
        {
            try
            {
                await _mediator.Send(new SendReceiptRequest(orderId));
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
