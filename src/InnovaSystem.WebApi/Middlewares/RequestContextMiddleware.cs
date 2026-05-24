using InnovaSystem.Core.Application.Common.Interfaces.CQRS;
using InnovaSystem.Core.Application.Common.Models;
using System.Security.Claims;

namespace InnovaSystem.WebApi.Middlewares
{
    public sealed class RequestContextMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// ASP.NET inyecta automáticamente: HttpContext actual y servicios DI
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="accessor"></param>
        /// <returns></returns>
        public async Task InvokeAsync(
            HttpContext httpContext,
            IRequestContextAccessor accessor)
        {
            // si no existe HttpContext válido
            // simplemente continúa

            if (httpContext is null)
            {
                await _next(httpContext);
                return;
            }

            accessor.Context = new RequestContext
            {
                UserId =
                    httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),

                UserName =
                    httpContext.User.Identity?.Name,

                Email =
                    httpContext.User.FindFirstValue(ClaimTypes.Email),

                IsAuthenticated =
                    httpContext.User.Identity?.IsAuthenticated ?? false,

                IpAddress =
                    httpContext.Connection.RemoteIpAddress?.ToString(),

                Device =
                    httpContext.Request.Headers["User-Agent"],

                Location =
                    httpContext.Request.Headers["X-Location"],

                CorrelationId =
                    httpContext.TraceIdentifier,

                RequestTime =
                    DateTime.UtcNow
            };

            await _next(httpContext);
        }
    }
}
