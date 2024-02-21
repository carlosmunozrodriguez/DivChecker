namespace DivChecker.Domain;

public static class DivCheckerEnumerator
{
    public static Result<IEnumerable<NumberResultPair>> GetResults(int input1, int input2, int sampleSize)
    {
        var errors = new List<string>();

        if (input1 <= 0)
        {
            errors.Add("Input1 must be greater than 0");
        }

        if (input2 <= 0)
        {
            errors.Add("Input2 must be greater than 0");
        }

        if (sampleSize < 0)
        {
            errors.Add("Sample size must be greater or equal than 0");
        }

        if (errors.Count != 0)
        {
            return Result<IEnumerable<NumberResultPair>>.Failure(errors);
        }

        return Result<IEnumerable<NumberResultPair>>.Success(GetResultsInternal(input1, input2, 0, sampleSize));
    }

    public static Result<IEnumerable<NumberResultPair>> GetResults(int input1, int input2, int start, int end)
    {
        var errors = new List<string>();

        if (input1 <= 0)
        {
            errors.Add("Input1 must be greater than 0");
        }

        if (input2 <= 0)
        {
            errors.Add("Input2 must be greater than 0");
        }

        if (start < 0)
        {
            errors.Add("Start must be greater or equal than 0");
        }

        if (end < 0)
        {
            errors.Add("End must be greater than 0");
        }

        if (start > end)
        {
            errors.Add("End must be grater than or equal than Start");
        }

        if (errors.Count != 0)
        {
            return Result<IEnumerable<NumberResultPair>>.Failure(errors);
        }

        return Result<IEnumerable<NumberResultPair>>.Success(GetResultsInternal(input1, input2, start, end));
    }

    private static IEnumerable<NumberResultPair> GetResultsInternal(int input1, int input2, int start, int end)
    {
        for (var i = start; i < end; i++)
        {
            var divBy1 = i.IsDivisibleBy(input1);
            var divBy2 = i.IsDivisibleBy(input2);

            var result = (divBy1, divBy2) switch
            {
                (true, true) => DivisibleBy.Both,
                (true, false) => DivisibleBy.Input1,
                (false, true) => DivisibleBy.Input2,
                _ => DivisibleBy.None
            };

            yield return new NumberResultPair(i, result);
        }
    }
}