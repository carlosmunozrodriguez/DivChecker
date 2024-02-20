namespace DivChecker.Domain;

public static class NumberExtensions
{
    public static bool IsDivisibleBy(this int number, int divisor) => number % divisor == 0;
}