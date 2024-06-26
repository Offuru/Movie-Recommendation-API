using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Infrastructure.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next) {  this.next = next; }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(ResourceMissingException ex)
            {
                await RespondToExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message, ex);
            }
            catch (Exception ex)
            {
                await RespondToExceptionAsync(context, HttpStatusCode.InternalServerError, "Internal Server Error", ex);
            }
        }

        private static Task RespondToExceptionAsync(HttpContext context,  HttpStatusCode statusCode, string message, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var respone = new
            {
                Message = message,
                Error = ex.GetType().Name,
                Timestamp = DateTime.UtcNow
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(respone, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
