using StockApi.ApplicationServices.API.ErrorHandling;

namespace StockApi.ApplicationServices.API.Domain
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}
