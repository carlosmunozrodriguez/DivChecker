namespace DivChecker.Api;

public record PagedResponse<T>
{
    public List<T> Results { get; init; } = [];

    public int TotalCount { get; init; }

    //public string? NextUrl { get; init; }

    //public string? PreviousUrl { get; init; }

    public PagedResponse(List<T> results, int totalCount)
    {
        Results = results;
        TotalCount = totalCount;
    }
}
