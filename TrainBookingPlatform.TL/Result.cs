namespace TrainBookingPlatform.TL
{
    public class Result
    {
        public bool IsSuccess { get;  }
        public string Error { get; }

        public Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }

    }

    public class Result<T> : Result
    {
        public T Value { get; set; }

        public Result(T value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public new static Result<T> Failure(string message)
        {
            return new Result<T>(default, false, message);
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }
    }
}
