using AutoMapper;
using MediatR;
using Repositories.Interfaces;

namespace Application.Commands.V1.Product
{
    public class CreateProduct : IRequestHandler<CreateProduct.Request, CreateProduct.Response>

    {
        private readonly IRepository<Repositories.Models.Product> _productRepository;
        private readonly IMapper _mapper;

        public class Request : IRequest<Response>
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Base64Image { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }

        public class Response 
        {
            public bool Success { get; set; }
            public int Id { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public CreateProduct(IRepository<Repositories.Models.Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request is null)
                return await GetErrorResponse("Request is null");

            var product = _mapper.Map<Repositories.Models.Product>(request);

            try
            { 
                var result = await _productRepository.Add(product);
                return await Task.FromResult(new Response { Success = true, Id = result.Id});

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
