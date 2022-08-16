using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dto;
using Application.Models.Dto.Requests;
using Application.Models.Dto.Responses;

namespace Application.Services.Interfaces
{
    public interface IPaymentHttpClient
    {
        public Task<ClientResult<TransactionResponse>> PostTransaction(TransactionRequest request,
            CancellationToken token);
    }
}
