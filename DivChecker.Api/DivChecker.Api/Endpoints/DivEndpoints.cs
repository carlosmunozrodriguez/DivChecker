using DivChecker.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DivChecker.Api.Endpoints;

public static class DivEndpoints
{
    public static Results<Ok<List<NumberResultPair>>, BadRequest<List<string>>> Get(int input1, int input2, int sampleSize)
    {
        Console.WriteLine($"input1: {input1}, input2: {input2}, sampleSize: {sampleSize}");
        var result = DivCheckerEnumerator.GetResults(input1, input2, sampleSize);

        if (!result.IsSuccess)
        {
            return TypedResults.BadRequest(result.Errors);
        }

        return TypedResults.Ok(result.Value!.ToList());
    }
}
