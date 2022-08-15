using Application.Commands.V1.Product;
using Application.Commands.V1.User;
using AutoMapper;
using ECommerceAPI.Models.Dto.Request.Product;
using ECommerceAPI.Models.Dto.Request.User;
using Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V1
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateProduct.Request>(request);

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

        [HttpPatch(Name = "PatchProduct")]
        public async Task<IActionResult> PatchProduct(PatchProductRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<PatchProductRequest>(request);
            
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
