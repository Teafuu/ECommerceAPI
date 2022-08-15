using AutoMapper;
using MediatR;
using Repositories.Interfaces;

namespace Application.Commands.V1.Order
{
    public class CreateOrder : IRequestHandler<CreateOrder.Request, CreateOrder.Response>
    {
        private readonly IRepository<Repositories.Models.Order> _orderRepository;
        private readonly IMapper _mapper;

        public class Request : IRequest<Response>
        {
            public int UserId { get; set; }
            public ICollection<int>? ProductIds { get; set; }
            public string? Address { get; set; }
            public bool Approved { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public int Id { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public CreateOrder(IRepository<Repositories.Models.Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request is null)
                return await GetErrorResponse("Request is null");

            var order = _mapper.Map<Repositories.Models.Order>(request);

            try
            {
                var result = await _orderRepository.Add(order);
                return await Task.FromResult(new Response { Success = true, Id = result.Id });

            }
            catch (ArgumentException ex)
            {
                return await GetErrorResponse(ex.Message);
            }

        }

        public async Task<Response> GetErrorResponse(string exception) =>
            await Task.FromResult(new Response { Success = false, Error = exception });
    }
}
