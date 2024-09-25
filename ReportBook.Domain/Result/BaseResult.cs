using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBook.Domain.Result
{
    public class BaseResult
    {
        public bool IsSuccess
        {
            get
            {
                return ErrorMessage == null ? true : false;
            }
        }

        public string? ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    }

    public class BaseResult<T> : BaseResult
    {
        public T? Data { get; set; }

        public BaseResult(string? errorMessage, int errorCode, T? data)
        {
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Data = data;
        }

        public BaseResult() { }
    }
}
