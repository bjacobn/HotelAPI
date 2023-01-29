using HotelAPI.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace HotelAPI.Core.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        //Itercept all requests 
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //Checks requests for exceptions
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while processing {nameof(context.Request.Path)}");
                await HandleExceptionAsync(context, ex);
            }
        }

        //Handles exceptions , returns in json format
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            //Handle all exceptions 
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetials
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message,
            };


            //Handle notfound exception
            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not Found";
                    break;
                default:
                    break;
            }

            //Returns exception message in Json format
            string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(response);
        }
    }

    public class ErrorDetials
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
