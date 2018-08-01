using System;
using System.Net;
using System.Threading.Tasks;
using AddressFinder.Domain.Entities;
using AddressFinder.Domain.SeedWork;
using Microsoft.AspNetCore.Http;

namespace AddressFinder.WebApi.CustomExceptionMiddleware
{
    /// <summary>
    /// Custom exception middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        #region Private members
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the exception asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Internal Server Error from the custom middleware. Error Message : {exception.Message} . Deatils: {exception.StackTrace}"
            }.ToString());
        }
    }
}
