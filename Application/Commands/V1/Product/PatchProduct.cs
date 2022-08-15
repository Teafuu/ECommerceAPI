using MediatR;
using Repositories.Interfaces;

namespace Application.Commands.V1.Product
{
    public class PatchProduct : IRequestHandler<PatchProduct.Request, PatchProduct.Response>
    {
        private readonly IRepository<Repositories.Models.Product> _productRepository;

        public class Request : IRequest<Response>
        {
           public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Base64Image { get; set; }
            public int? Quantity { get; set; }
            public int? Price { get; set; }
        }

        public class Response 
        {
            public bool Success { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public PatchProduct(IRepository<Repositories.Models.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            if (request is null)
                return await GetErrorResponse("Request is null");

            try
            {
                var existingProduct = await _productRepository.Get(request.Id);

                if (existingProduct is null)
                    return await GetErrorResponse("Product doesn't exist");

                existingProduct.Name = request.Name ?? existingProduct.Name;
                existingProduct.Description = request.Description ?? existingProduct.Description;
                existingProduct.Base64Image = request.Base64Image ?? existingProduct.Base64Image;
                existingProduct.Quantity = request.Quantity ?? existingProduct.Quantity;
                existingProduct.Price = request.Price ?? existingProduct.Price;

                var result = await _productRepository.Update(existingProduct);

                return await Task.FromResult(new Response { Success = result});

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
