using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Response
{
    public class BaseResponse<T>
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public BaseResponse(bool status, T data, string errorMessage)
        {
            this.Status = status;
            this.Data = data;
            this.ErrorMessage = errorMessage;
        }
    }
}
