using DiscountSystem.Application.Queries.ProductQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DiscountSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var response = await _mediator.Send(new GetAllProductQueryRequest());
            if (response.StatusCode == (int)HttpStatusCode.BadRequest) return BadRequest(response);
            return Ok(response);
        }
    }
}
