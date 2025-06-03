using System.Net;

namespace API.Aventureo.Models
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                string message = "Usuario no autenticado o autorizado.";
                await HandleError400(context, ex, message);
            }
            catch (KeyNotFoundException ex)
            {
                string message = "Ha ocurrido un error, no se ha encontrado ningún dato";
                await HandleError400(context, ex, message);
            }
            catch (Exception ex)
            {
                await HandleError500(context, ex);
            }
        }

        private async Task HandleError500(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error" + exception.Message
            }.ToString());
        }

        private async Task HandleError400(HttpContext context, Exception exception, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = message + " " + exception.Message
            }.ToString());
        }
    }
}
