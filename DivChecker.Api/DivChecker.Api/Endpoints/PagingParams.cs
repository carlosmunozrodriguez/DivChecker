using DivChecker.Domain;

namespace DivChecker.Api.Endpoints;

public class PagingParams
{
    public int Page { get; }
    public int PageSize { get; }

    public int StartIndex => (Page - 1) * PageSize;
    public int EndIndex => Page * PageSize;

    private PagingParams(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public static Result<PagingParams> Create(int page, int pageSize)
    {
        var errors = new List<string>();

        if (page < 1)
        {
            errors.Add("Page must be greater or equal than 1");
        }

        if (pageSize < 1)
        {
            errors.Add("PageSize must be greater or equal than 1");
        }

        if (errors.Count != 0)
        {
            return Result<PagingParams>.Failure(errors);
        }

        return Result<PagingParams>.Success(new PagingParams(page, pageSize));
    }
}