namespace InnovaSystem.Core.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public Error? Error { get; }
        public List<ApiErrorCode>? ApiErrors { get; set; }

        protected Result(bool isSuccess, Error? error, List<ApiErrorCode>? apiErrorCodes = null)
        {
            IsSuccess = isSuccess;
            Error = error;
            ApiErrors = apiErrorCodes;
        }

        public static Result Success()
        {
            return new(true, null, null);
        }

        public static Result Failure(Error error, List<ApiErrorCode>? apiErrorCodes = null)
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
            Error? error,
            List<ApiErrorCode>? apiErrors)
            : base(isSuccess, error, apiErrors)
        {
            Data = data;
        }

        public static Result<T> Success(T data)
            => new(true, data, null, null);

        public static Result<T> Failure(Error? error, T? data = default, List<ApiErrorCode>? apiErrors = null)
            => new(false, data, error, apiErrors);
    }
}
