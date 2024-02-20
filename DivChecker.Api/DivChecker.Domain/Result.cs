namespace DivChecker.Domain;
public sealed record Result<T>
{
    public bool IsSuccess { get; }

    public T? Value { get; }

    public List<string>? Errors { get; }

    private Result(bool isSuccess, T? value, List<string>? errors = default)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors ?? [];
    }

    public static Result<T> Success(T value) => new(true, value);

    public static Result<T> Failure(List<string> errors) => new(false, default, errors);
}
