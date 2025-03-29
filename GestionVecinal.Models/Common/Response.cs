using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.Common
{
    public class Response<T>
    {
        public T? Value { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Error? Error { get; set; }
        public bool IsError { get { if (Error != null) return false; return true; } }
        public void setValue(T value, bool success, string message)
        {
            Value = value;
            Success = success;
            Message = message;
        }

        public void setError(string message, string stackTrace)
        {
            Error = new Error
            {
                Message = message,
                StackTrace = stackTrace
            };
            Success = false;
        }
    }

    public class Error
    {
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
    }
}
