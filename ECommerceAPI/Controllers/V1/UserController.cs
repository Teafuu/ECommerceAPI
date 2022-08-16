using Application.Commands.V1.User;
using AutoMapper;
using ECommerceAPI.Models.Dto.Request.User;
using Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V1
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly AuthenticationProvider _authenticationProvider;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, AuthenticationProvider authenticationProvider, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _authenticationProvider = authenticationProvider;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUser.Request>(request);

            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                var token = _authenticationProvider.CreateToken(result.Id);
                return Ok(token);

            }
            catch (ExeuctionFailedException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost(Name = "ValidateCredentials")]
        public async Task<IActionResult> ValidateCredentials(ValidateCredentialsRequest request)
        {
            var command = _mapper.Map<ValidateUser.Request>(request);

            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);

            }
            catch (ExeuctionFailedException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
