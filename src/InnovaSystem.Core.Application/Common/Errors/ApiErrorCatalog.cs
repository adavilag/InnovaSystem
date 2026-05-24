using InnovaSystem.CrossCutting.Models;
using System.Text.Json;

namespace InnovaSystem.Core.Application.Common.Errors
{
    public static class ApiErrorCatalog
    {
        private static readonly Dictionary<string, ApiError> _errors;

        static ApiErrorCatalog()
        {
            var filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Resources",
                "ApiErrorCatalog.json");

            var json = File.ReadAllText(filePath);

            _errors = JsonSerializer.Deserialize<Dictionary<string, ApiError>>(json)
                      ?? new Dictionary<string, ApiError>();
        }

        public static ApiError Get(string errorCode)
        {
            return _errors.TryGetValue(errorCode, out var error)
                ? error
                : UknowError;
        }

        public static readonly ApiError UknowError = new()
        {
            ErrorCode = "UNKNOWN_ERROR",
            ErrorTitle = "Error desconocido",
            FriendlyErrorDescription = "Ha ocurrido un error inesperado.",
            TechnicalErrorDescription = "Ha ocurrido un error desconocido que no está registrado en el catálogo de errores."
        };
    }
}
