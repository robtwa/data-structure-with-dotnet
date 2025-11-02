using src.leetcode;

namespace unitTests;

public class solutionTests
{
    [Fact]
    public void solution_ArrayWithNegativesAndPositives_ReturnsExpectedTriplets()
    {
        var solver = new ThreeSum();
        int[] nums = { -1, 0, 1, 2, -1, -4 };

        var result = solver.solution(nums);

        var expected = new List<IList<int>>
        {
            new List<int>{ -1, -1, 2 },
            new List<int>{ -1, 0, 1 }
        };

        Assert.Equal(
            expected.Select(x => string.Join(",", x)).OrderBy(x => x),
            result.Select(x => string.Join(",", x)).OrderBy(x => x)
        );
    }

    [Fact]
    public void solution_AllZeros_ReturnsSingleTriplet()
    {
        var solver = new ThreeSum();
        int[] nums = { 0, 0, 0, 0 };

        var result = solver.solution(nums);

        var expected = new List<IList<int>> { new List<int> { 0, 0, 0 } };
        Assert.Single(result);
        Assert.Equal(expected[0], result[0]);
    }

    [Fact]
    public void solution_NoTriplets_ReturnsEmptyList()
    {
        var solver = new ThreeSum();
        int[] nums = { 1, 2, 3 };

        var result = solver.solution(nums);

        Assert.Empty(result);
    }

    [Fact]
    public void solution_ArrayWithDuplicates_ReturnsUniqueTriplets()
    {
        var solver = new ThreeSum();
        int[] nums = { -2, 0, 0, 2, 2 };

        var result = solver.solution(nums);

        var expected = new List<IList<int>> { new List<int> { -2, 0, 2 } };
        Assert.Single(result);
        Assert.Equal(expected[0], result[0]);
    }
}