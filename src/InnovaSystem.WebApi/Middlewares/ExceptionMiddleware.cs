using FluentValidation;
using InnovaSystem.CrossCutting.Models;
using System.Diagnostics;
using InnovaSystem.CrossCutting.Extensions;
using InnovaSystem.Core.Application.Common.Errors;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            _logger.LogInformation("Request iniciada: {Method} {Path}", context.Request.Method, context.Request.Path);

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation("Response finalizada ({Method} {Path}): {StatusCode}  ejecutado en {ElapsedMilliseconds} ms", 
                context.Request.Method, 
                context.Request.Path, 
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 422;

            var dataValidationErrors = ex.Errors
                .Select(x => new EntityValidationError
                {
                    Property = x.PropertyName,
                    Message = x.ErrorMessage
                })
                .ToList();

            var result = Result<List<EntityValidationError>>.Failure(
                HttpError.Validation($"Se han detectado errores de validación"), 
                dataValidationErrors);

            context.Response.StatusCode = result.HttpError!.StatusCode;

            _logger.LogError($"{result.HttpError?.Message}: {dataValidationErrors.ToJson()}");

            await context.Response.WriteAsJsonAsync(result);
        }
        catch (Exception)
        {
            var apiError = ApiErrorCatalog.Get(ApiErrorConstants.ErrorNotManaged);
            HttpError httpError = HttpError.Internal("Ha ocurrido un error no controlado!");

            var result = Result<List<EntityValidationError>>.Failure(
                httpError, 
                new List<ApiError> { apiError });

            context.Response.StatusCode = httpError.StatusCode;

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}