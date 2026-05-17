namespace InnovaSystem.Core.Domain.Common
{
    public sealed class Error
    {
        public string Code { get; }
        public string Message { get; }
        public int StatusCode { get; }
        public DateTime Timestamp { get; }

        private Error(
            string code,
            string message,
            int statusCode)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
            Timestamp = DateTime.UtcNow;
        }

        #region Common Errors

        public static Error BadRequest(
            string message = "The request is invalid.",
            string code = "BAD_REQUEST")
            => new(code, message, 400);

        public static Error Unauthorized(
            string message = "Unauthorized access.",
            string code = "UNAUTHORIZED")
            => new(code, message, 401);

        public static Error Forbidden(
            string message = "Access denied.",
            string code = "FORBIDDEN")
            => new(code, message, 403);

        public static Error NotFound(
            string message = "Resource not found.",
            string code = "NOT_FOUND")
            => new(code, message, 404);

        public static Error Conflict(
            string message = "Resource conflict.",
            string code = "CONFLICT")
            => new(code, message, 409);

        public static Error Validation(
            string message = "Validation failed.",
            string code = "VALIDATION_ERROR")
            => new(code, message, 422);

        public static Error Internal(
            string message = "An unexpected error occurred.",
            string code = "INTERNAL_SERVER_ERROR")
            => new(code, message, 500);

        #endregion

        public override string ToString()
        {
            return $"{Code}: {Message}";
        }
    }
}
