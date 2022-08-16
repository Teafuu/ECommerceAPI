using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Models.Dto;
using Application.Models.Dto.Requests;
using Application.Models.Dto.Responses;
using Application.Services.Interfaces;
using Newtonsoft.Json;

namespace Application.Services
{
    public class PaymentHttpClient : IPaymentHttpClient
    {
        private readonly HttpClient _client;

        public PaymentHttpClient(HttpClient client)
        {
            _client = client;
        }


        public async Task<ClientResult<TransactionResponse>> PostTransaction(TransactionRequest request, CancellationToken token)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));

            var response = await _client.PostAsync("Transactions", httpContent, token);

            if (!response.IsSuccessStatusCode)
                return ClientResult<TransactionResponse>.Failure(response.ReasonPhrase);

            var content = await response.Content.ReadAsStringAsync(token);
            try
            {
                return ClientResult<TransactionResponse>.Successful(JsonConvert.DeserializeObject<TransactionResponse>(content));
            }
            catch (Exception e)
            {
                return ClientResult<TransactionResponse>.Failure(e.Message);
            }
            
        }
    }
}
