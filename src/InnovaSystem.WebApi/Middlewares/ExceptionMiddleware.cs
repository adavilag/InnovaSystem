using FluentValidation;
using InnovaSystem.Core.Domain.Common;
using Microsoft.IdentityModel.Tokens.Experimental;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
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
                Error.Validation(
                    "One or more validation errors occurred."),
                dataValidationErrors);

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}