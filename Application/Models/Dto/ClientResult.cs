using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto
{
    public class ClientResult<T>
    {
        public T Response { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }

        public static ClientResult<T> Successful(T response) =>
            new()
            {
                Success = true,
                Response = response
            };

        public static ClientResult<T> Failure(string error) =>
            new()
            {
                Success = false,
                Error = error
            };
    }
}
