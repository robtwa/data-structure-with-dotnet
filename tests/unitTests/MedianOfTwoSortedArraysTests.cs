using src.leetcode;
using Xunit;

namespace unitTests;

public class MedianOfTwoSortedArraysTests
{
    // MethodName_TestScenario_ExpectedResult
    [Fact]
    public void solution_SimpleOddLength_ReturnsCorrectMedian()
    {
        var solver = new MedianOfTwoSortedArrays();
        double result = solver.solution(
            new int[] { 1, 3 },
            new int[] { 2 }
        );

        Assert.Equal(2.0, result);
    }

    [Fact]
    public void solution_SimpleEvenLength_ReturnsCorrectMedian()
    {
        var solver = new MedianOfTwoSortedArrays();
        double result = solver.solution(
            new int[] { 1, 2 },
            new int[] { 3, 4 }
        );

        Assert.Equal(2.5, result);
    }

    [Fact]
    public void solution_OneEmptyArray_ReturnsMedianOfNonEmpty()
    {
        var solver = new MedianOfTwoSortedArrays();
        double result = solver.solution(
            new int[] { },
            new int[] { 1, 2, 3, 4 }
        );

        Assert.Equal(2.5, result);
    }

    [Fact]
    public void solution_DifferentSizes_ReturnsCorrectMedian()
    {
        var solver = new MedianOfTwoSortedArrays();
        double result = solver.solution(
            new int[] { 1, 3, 8, 9, 15 },
            new int[] { 7, 11, 18, 19, 21, 25 }
        );

        Assert.Equal(11.0, result);
    }
}
