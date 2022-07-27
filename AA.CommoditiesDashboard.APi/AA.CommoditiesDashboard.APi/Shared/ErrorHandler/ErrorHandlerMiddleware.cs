using Newtonsoft.Json;
using System.Net;

namespace AA.CommoditiesDashboard.APi.Shared.ErrorHandler
{
    public class ErrorHandlerMiddleware
    {
        public RequestDelegate _next;
        public HttpContext _context;
        
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;                        
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {                
                _context = context;
                await _next(context);
            }
            catch (Exception ex)
            {             
                await HandleException(_context, ex);
            }
            finally
            {                
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "GE" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorMessage);
        }

    }
}
