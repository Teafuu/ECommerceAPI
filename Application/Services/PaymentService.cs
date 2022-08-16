using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dto.Requests;
using Application.Models.Dto.Responses;
using Application.Services.Interfaces;

namespace Application.Services
{
    public class PaymentService
    {
        private readonly IPaymentHttpClient _client;

        public PaymentService(IPaymentHttpClient client)
        {
            _client = client;
        }

        public async Task<TransactionResponse?> ProcessTransaction(TransactionRequest request, CancellationToken token)
        {
            if (request is null)
                throw new ArgumentException("Transaction Request is null");

            var result = await _client.PostTransaction(request, token);

            if (!result.Success)
                throw new ArgumentException("Transaction was unsuccessful");

            return result.Response;
        }
    }
}
