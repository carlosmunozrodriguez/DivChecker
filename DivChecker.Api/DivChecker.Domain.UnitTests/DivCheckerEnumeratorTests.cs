using FluentAssertions;

namespace DivChecker.Domain.UnitTests;

public class DivCheckerEnumeratorTests
{
    const int NegativerNumber = -1;
    const int Zero = 0;
    const int PositiveNumber = 1;

    [Theory]
    [InlineData(NegativerNumber, NegativerNumber, NegativerNumber, false, 3)]
    [InlineData(NegativerNumber, NegativerNumber, Zero, false, 2)]
    [InlineData(NegativerNumber, NegativerNumber, PositiveNumber, false, 2)]
    [InlineData(NegativerNumber, Zero, NegativerNumber, false, 3)]
    [InlineData(NegativerNumber, Zero, Zero, false, 2)]
    [InlineData(NegativerNumber, Zero, PositiveNumber, false, 2)]
    [InlineData(NegativerNumber, PositiveNumber, NegativerNumber, false, 2)]
    [InlineData(NegativerNumber, PositiveNumber, Zero, false, 1)]
    [InlineData(NegativerNumber, PositiveNumber, PositiveNumber, false, 1)]


    [InlineData(Zero, NegativerNumber, NegativerNumber, false, 3)]
    [InlineData(Zero, NegativerNumber, Zero, false, 2)]
    [InlineData(Zero, NegativerNumber, PositiveNumber, false, 2)]
    [InlineData(Zero, Zero, NegativerNumber, false, 3)]
    [InlineData(Zero, Zero, Zero, false, 2)]
    [InlineData(Zero, Zero, PositiveNumber, false, 2)]
    [InlineData(Zero, PositiveNumber, NegativerNumber, false, 2)]
    [InlineData(Zero, PositiveNumber, Zero, false, 1)]
    [InlineData(Zero, PositiveNumber, PositiveNumber, false, 1)]


    [InlineData(PositiveNumber, NegativerNumber, NegativerNumber, false, 2)]
    [InlineData(PositiveNumber, NegativerNumber, Zero, false, 1)]
    [InlineData(PositiveNumber, NegativerNumber, PositiveNumber, false, 1)]
    [InlineData(PositiveNumber, Zero, NegativerNumber, false, 2)]
    [InlineData(PositiveNumber, Zero, Zero, false, 1)]
    [InlineData(PositiveNumber, Zero, PositiveNumber, false, 1)]
    [InlineData(PositiveNumber, PositiveNumber, NegativerNumber, false, 1)]
    [InlineData(PositiveNumber, PositiveNumber, Zero, true, 0)]
    [InlineData(PositiveNumber, PositiveNumber, PositiveNumber, true, 0)]
    public void When_InvalidParameter_Then_Returns_FailedWithErrors(int input1, int input2, int sampleSize, bool success, int errorCount)
    {
        var result = DivCheckerEnumerator.GetResults(input1, input2, sampleSize);

        result.IsSuccess.Should().Be(success);
        result.Errors.Should().HaveCount(errorCount);
    }

    [Fact]
    public void Test_Two_Three_Twenty()
    {
        var result = DivCheckerEnumerator.GetResults(2, 3, 20);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(20);
        result.Value.Should().BeEquivalentTo(new[]
        {
            new NumberResultPair(0, DivisibleBy.Both),
            new NumberResultPair(1, DivisibleBy.None),
            new NumberResultPair(2, DivisibleBy.Input1),
            new NumberResultPair(3, DivisibleBy.Input2),
            new NumberResultPair(4, DivisibleBy.Input1),
            new NumberResultPair(5, DivisibleBy.None),
            new NumberResultPair(6, DivisibleBy.Both),
            new NumberResultPair(7, DivisibleBy.None),
            new NumberResultPair(8, DivisibleBy.Input1),
            new NumberResultPair(9, DivisibleBy.Input2),
            new NumberResultPair(10, DivisibleBy.Input1),
            new NumberResultPair(11, DivisibleBy.None),
            new NumberResultPair(12, DivisibleBy.Both),
            new NumberResultPair(13, DivisibleBy.None),
            new NumberResultPair(14, DivisibleBy.Input1),
            new NumberResultPair(15, DivisibleBy.Input2),
            new NumberResultPair(16, DivisibleBy.Input1),
            new NumberResultPair(17, DivisibleBy.None),
            new NumberResultPair(18, DivisibleBy.Both),
            new NumberResultPair(19, DivisibleBy.None)
        });
    }

    [Fact]
    public void Test_Three_Five_Twenty()
    {
        var result = DivCheckerEnumerator.GetResults(3, 5, 20);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(20);
        result.Value.Should().BeEquivalentTo(new[]
        {
            new NumberResultPair(0, DivisibleBy.Both),
            new NumberResultPair(1, DivisibleBy.None),
            new NumberResultPair(2, DivisibleBy.None),
            new NumberResultPair(3, DivisibleBy.Input1),
            new NumberResultPair(4, DivisibleBy.None),
            new NumberResultPair(5, DivisibleBy.Input2),
            new NumberResultPair(6, DivisibleBy.Input1),
            new NumberResultPair(7, DivisibleBy.None),
            new NumberResultPair(8, DivisibleBy.None),
            new NumberResultPair(9, DivisibleBy.Input1),
            new NumberResultPair(10, DivisibleBy.Input2),
            new NumberResultPair(11, DivisibleBy.None),
            new NumberResultPair(12, DivisibleBy.Input1),
            new NumberResultPair(13, DivisibleBy.None),
            new NumberResultPair(14, DivisibleBy.None),
            new NumberResultPair(15, DivisibleBy.Both),
            new NumberResultPair(16, DivisibleBy.None),
            new NumberResultPair(17, DivisibleBy.None),
            new NumberResultPair(18, DivisibleBy.Input1),
            new NumberResultPair(19, DivisibleBy.None)
        });
    }
}