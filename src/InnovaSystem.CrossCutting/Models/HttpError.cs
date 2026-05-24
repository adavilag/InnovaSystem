namespace InnovaSystem.CrossCutting.Models
{
    public sealed class HttpError
    {
        public int StatusCode { get; }
        public string StatusCodeName { get; }
        public string Message { get; }
        public DateTime Timestamp { get; }

        private HttpError(
            string errorName,
            string message,
            int statusCode)
        {
            StatusCodeName = errorName;
            Message = message;
            StatusCode = statusCode;
            Timestamp = DateTime.UtcNow;
        }

        #region Common Errors

        public static HttpError BadRequest(
            string message = "The request is invalid.")
            => new("BAD_REQUEST", message, 400);

        public static HttpError Unauthorized(
            string message = "Unauthorized access.")
            => new("UNAUTHORIZED", message, 401);

        public static HttpError Forbidden(
            string message = "Access denied.")
            => new("FORBIDDEN", message, 403);

        public static HttpError NotFound(
            string message = "Resource not found.")
            => new("NOT_FOUND", message, 404);

        public static HttpError Conflict(
            string message = "Resource conflict.")
            => new("CONFLICT", message, 409);

        public static HttpError Validation(
            string message = "Validation failed.")
            => new("VALIDATION_ERROR", message, 422);

        public static HttpError Internal(
            string message = "An unexpected error occurred.")
            => new("INTERNAL_SERVER_ERROR", message, 500);

        #endregion

        public override string ToString()
        {
            return $"{StatusCodeName}: {Message}";
        }
    }
}
