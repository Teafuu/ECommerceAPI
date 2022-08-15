using Application.Commands.V1.Order;
using AutoMapper;
using ECommerceAPI.Models.Dto.Request.Order;
using Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V1
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateOrder")]
        public async Task<IActionResult> CreateProduct(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateOrder.Request>(request);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);

            }
            catch (ExeuctionFailedException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
