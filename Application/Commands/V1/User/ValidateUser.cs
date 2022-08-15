using MediatR;
using Repositories.Interfaces;
using BCrypt.Net;

namespace Application.Commands.V1.User
{
    public class ValidateUser : IRequestHandler<ValidateUser.Request, ValidateUser.Response>
    {
        private readonly IRepository<Repositories.Models.User> _userRepository;

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

        public ValidateUser(IRepository<Repositories.Models.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if(request?.Email is null || request?.Password is null)
                return await Task.FromResult(new Response { Success = false, Error = "Invalid Arguments"});

            var getUser = await _userRepository.GetByExpression(x => x.Email.ToLower() == request.Email.ToLower());

            if (getUser is null)
            {
                return await GetErrorResponse("User doesn't exist");
            }

            var validation = BCrypt.Net.BCrypt.Verify(request.Password, getUser.Password);
            
            return await Task.FromResult(new Response {Success = validation});
        }
        public async Task<Response> GetErrorResponse(string exception) =>
            await Task.FromResult(new Response { Success = false, Error = exception });
    }
}
