namespace InnovaSystem.Core.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public HttpError? Error { get; }
        public List<ApiError>? ApiErrors { get; set; }

        protected Result(bool isSuccess, HttpError? error, List<ApiError>? apiErrorCodes = null)
        {
            IsSuccess = isSuccess;
            Error = error;
            ApiErrors = apiErrorCodes;
        }

        public static Result Success()
        {
            return new(true, null, null);
        }

        public static Result Failure(HttpError error, List<ApiError>? apiErrorCodes = null)
        {
            return new(false, error, apiErrorCodes);
        }
    }

    public class Result<T> : Result
    {
        public T? Data { get; }

        private Result(
            bool isSuccess,
            T? data,
            HttpError? error,
            List<ApiError>? apiErrors)
            : base(isSuccess, error, apiErrors)
        {
            Data = data;
        }

        public static Result<T> Success(T data)
            => new(true, data, null, null);

        public static Result<T> Failure(HttpError? error, T? data = default, List<ApiError>? apiErrors = null)
            => new(false, data, error, apiErrors);
    }
}
