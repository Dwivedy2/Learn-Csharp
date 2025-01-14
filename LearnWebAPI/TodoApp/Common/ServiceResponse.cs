using System.Runtime.CompilerServices;

namespace Common
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool IsSuccessful { get; set; }
        public ServiceResponse<T> GetResponse(T? data, string message, bool isSuccessful = false)
        {
            Data = data;
            Message = message;
            IsSuccessful = isSuccessful;
            return this;
        }
    }
}
