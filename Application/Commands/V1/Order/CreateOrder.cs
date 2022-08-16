using Application.Models.Dto.Requests;
using Application.Services;
using AutoMapper;
using MediatR;
using Repositories.Interfaces;

namespace Application.Commands.V1.Order
{
    public class CreateOrder : IRequestHandler<CreateOrder.Request, CreateOrder.Response>
    {
        private readonly IRepository<Repositories.Models.Order> _orderRepository;
        private readonly IRepository<Repositories.Models.Product> _productRepository;
        private readonly PaymentService _paymentService;
        private readonly IMapper _mapper;

        public class Request : IRequest<Response>
        {
            public int UserId { get; set; }
            public ICollection<int>? ProductIds { get; set; }
            public string? Address { get; set; }
            public string CardNumber { get; set; }
            public string ExpiryMonth { get; set; }
            public string ExpiryYear { get; set; }
            public string Cvv { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public int Id { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public CreateOrder(
            IRepository<Repositories.Models.Order> orderRepository,
            IRepository<Repositories.Models.Product> productRepository,
            PaymentService paymentService,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request is null)
                return await GetErrorResponse("Request is null");

            var transactionRequest = _mapper.Map<TransactionRequest>(request);
            var totalChargeAmount = 0;

            foreach (var product in request.ProductIds)
            {
                var response = await _productRepository.Get(product);
                if(response is null || response.Quantity <= 0)
                    continue;

                totalChargeAmount += response.Price;
                response.Quantity--;

                await _productRepository.Update(response);
            }

            transactionRequest.ChargedAmount = totalChargeAmount;

            var transactionResult = await _paymentService.ProcessTransaction(transactionRequest, cancellationToken);
            if (transactionResult is null || !transactionResult.Approved)
                return new Response {Error = "Failed Response", Success = false};

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
