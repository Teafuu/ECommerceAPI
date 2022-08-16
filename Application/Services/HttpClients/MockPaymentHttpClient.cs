using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dto;
using Application.Models.Dto.Requests;
using Application.Models.Dto.Responses;
using Application.Services.Interfaces;
using Newtonsoft.Json;

namespace Application.Services.HttpClients
{
    internal class MockPaymentHttpClient : IPaymentHttpClient
    {
        private readonly HttpClient _client;

        public MockPaymentHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ClientResult<TransactionResponse>> PostTransaction(TransactionRequest request,
            CancellationToken token) =>
            new()
            {
                Success = true,
                Response = new TransactionResponse
                {
                    Approved = true,
                    Message = "Transaction completed"
                }
            };
    }
}
