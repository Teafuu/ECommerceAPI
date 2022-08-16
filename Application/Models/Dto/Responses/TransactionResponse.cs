using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto.Responses
{
    public class TransactionResponse
    {
        public bool Approved { get; set; }
        public string Message { get; set; }
    }
}
