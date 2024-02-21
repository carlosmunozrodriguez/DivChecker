using DivChecker.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DivChecker.Api.Endpoints;

public static class DivEndpoints
{
    public static void MapDivEndpoints(this WebApplication app)
    {
        app.MapGet("/divs", Get)
            .WithName("GetDivs")
            .WithOpenApi()
            .CacheOutput(x => x.SetVaryByQuery("input1", "input2", "sampleSize"));

        app.MapGet("/divs2", Get2)
            .WithName("GetDivs2")
            .WithOpenApi()
            .CacheOutput(x => x.SetVaryByQuery("input1", "input2", "sampleSize", "page", "pageSize"));
    }

    private static Results<Ok<List<NumberResultPair>>, BadRequest<List<string>>> Get(int input1, int input2, int sampleSize)
    {
        //Console.WriteLine($"input1: {input1}, input2: {input2}, sampleSize: {sampleSize}");
        var result = DivCheckerEnumerator.GetResults(input1, input2, sampleSize);

        if (!result.IsSuccess)
        {
            return TypedResults.BadRequest(result.Errors);
        }

        return TypedResults.Ok(result.Value!.ToList());
    }

    private static Results<Ok<List<NumberResultPair>>, BadRequest<List<string>>> Get2(int input1, int input2, int sampleSize, int page = 1, int pageSize = 10)
    {
        var pagingParamsResult = PagingParams.Create(page, pageSize);

        if (!pagingParamsResult.IsSuccess)
        {
            return TypedResults.BadRequest(pagingParamsResult.Errors);
        }

        var pagingParams = pagingParamsResult.Value!;

        //Console.WriteLine($"input1: {input1}, input2: {input2}, sampleSize: {sampleSize}, page: {page}, pageSize: {pageSize}");
        var result = DivCheckerEnumerator.GetResults(input1, input2, pagingParams.StartIndex, Math.Min(pagingParams.EndIndex, sampleSize));

        if (!result.IsSuccess)
        {
            return TypedResults.BadRequest(result.Errors);
        }

        return TypedResults.Ok(result.Value!.ToList());
    }
}