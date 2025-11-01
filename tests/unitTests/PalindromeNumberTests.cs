using src.leetcode;

namespace unitTests;

public class PalindromeNumberTests
{
    // MethodName_TestScenario_ExpectedResult
    [Fact]
    public void solution_PositivePalindrome_ReturnsTrue()
    {
        var solver = new PalindromeNumber();
        bool result = solver.solution(121);
        Assert.True(result);
    }

    [Fact]
    public void solution_NegativeNumber_ReturnsFalse()
    {
        var solver = new PalindromeNumber();
        bool result = solver.solution(-121);
        Assert.False(result);
    }

    [Fact]
    public void solution_NotPalindrome_ReturnsFalse()
    {
        var solver = new PalindromeNumber();
        bool result = solver.solution(123);
        Assert.False(result);
    }

    [Fact]
    public void solution_SingleDigit_ReturnsTrue()
    {
        var solver = new PalindromeNumber();
        bool result = solver.solution(7);
        Assert.True(result);
    }

    [Fact]
    public void solution_NumberEndingWithZero_ReturnsFalse()
    {
        var solver = new PalindromeNumber();
        bool result = solver.solution(10);
        Assert.False(result);
    }
}

