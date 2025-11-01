using src.leetcode;

namespace unitTests;

public class ReverseIntegerTests
{
    [Fact]
    public void Reverse_SingleDigit_ReturnsSameNumber()
    {
        var ReverseInteger = new ReverseInteger();

        int result = ReverseInteger.solution(7);

        Assert.Equal(7, result);
    }
    
    [Fact]
    public void Reverse_PositiveInput_ReturnsReversedNumber()
    {
        var ReverseInteger = new ReverseInteger();

        int result = ReverseInteger.solution(123);

        Assert.Equal(321, result);
    }

    [Fact]
    public void Reverse_NegativeInput_ReturnsReversedNegative()
    {
        var ReverseInteger = new ReverseInteger();

        int result = ReverseInteger.solution(-456);

        Assert.Equal(-654, result);
    }

    [Fact]
    public void Reverse_TrailingZero_ReturnsReversedWithoutLeadingZero()
    {
        var ReverseInteger = new ReverseInteger();

        int result = ReverseInteger.solution(120);

        Assert.Equal(21, result);
    }

    [Fact]
    public void Reverse_OverflowInput_ReturnsZero()
    {
        var ReverseInteger = new ReverseInteger();

        int result = ReverseInteger.solution(1534236469);

        Assert.Equal(0, result);
    }


}
