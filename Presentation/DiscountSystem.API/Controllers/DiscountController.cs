using DiscountSystem.Application.Commands.DiscountCommands;
using DiscountSystem.Application.Queries.DiscountQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DiscountSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscount([FromBody]CreateDiscountCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if(response.StatusCode == (int)HttpStatusCode.BadRequest) return BadRequest(response);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscountList()
        {
            var response = await _mediator.Send(new GetAllDiscountQueryRequest());
            if (response.StatusCode == (int)HttpStatusCode.BadRequest) return BadRequest(response);
            return Ok(response);
        }
    }
}
