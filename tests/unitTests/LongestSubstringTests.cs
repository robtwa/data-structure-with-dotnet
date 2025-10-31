using src.leetcode;

public class LongestSubstringTests
{
    // MethodName_TestScenario_ExpectedResult
    
    [Fact]
    public void LongestSubstring_sameChars_Returns1()
    {
        var solver = new LongestSubstring();
        string input = "bbbbb";
        int expected = 1;

        Assert.Equal(expected, solver.solution(input));
    }
    
    [Fact]
    public void LongestSubstring_4Chars_Returns2()
    {
        var solver = new LongestSubstring();
        string input = "abaa";
        int expected = 2;

        Assert.Equal(expected, solver.solution(input));
    }

    
    [Fact]
    public void LongestSubstring_7Chars_Returns3()
    {
        var solver = new LongestSubstring();
        string input = "abcbcbb";
        int expected = 3;

        Assert.Equal(expected, solver.solution(input));
    }
    
}