using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockApi.ApplicationServices.API.ErrorHandling;
using System.Net;

namespace StockAPI.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        // private readonly ILogger<ApiControllerBase> logger;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
            // logger = logger;
        }
        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new
                    {
                        property = x.Key,
                        errors = x.Value.Errors
                    }));
            }

            var response = await _mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }
        private IActionResult ErrorResponse(ErrorModel errorModel)
        {

            // _logger.LogError($"We have error: {errorModel.Error}!");
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }
        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
