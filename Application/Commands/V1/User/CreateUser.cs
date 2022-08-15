using AutoMapper;
using MediatR;
using Repositories.Interfaces;

namespace Application.Commands.V1.User
{
    public class CreateUser : IRequestHandler<CreateUser.Request, CreateUser.Response>

    {
        private readonly IRepository<Repositories.Models.User> _userRepository;
        private readonly IMapper _mapper;

        public class Request : IRequest<Response>
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

        public class Response 
        {
            public bool Success { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public CreateUser(IRepository<Repositories.Models.User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request is null)
                return await GetErrorResponse("Request is null");


            var user = _mapper.Map<Repositories.Models.User>(request);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            try
            { 
                await _userRepository.Add(user);
                return await Task.FromResult(new Response { Success = true });

            }
            catch (ArgumentException ex)
            {
                return await GetErrorResponse(ex.Message);
            }
        }

        public async Task<Response> GetErrorResponse(string exception) =>
            await Task.FromResult(new Response {Success = false, Error = exception});
    }
}
