using src.leetcode;

namespace unitTests;

public class ContainerWithMostWaterTests
{
    [Fact]
    public void MaxArea_RegularHeights_ReturnsCorrectArea()
    {
        var solution = new ContainerWithMostWater();
        int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

        int result = solution.MaxArea(height);

        Assert.Equal(49, result); 
    }

    [Fact]
    public void MaxArea_AllEqualHeights_ReturnsMaxWidth()
    {
        var solution = new ContainerWithMostWater();
        int[] height = { 5, 5, 5, 5, 5 };

        int result = solution.MaxArea(height);

        Assert.Equal(20, result); // 4 × 5 = 20
    }

    [Fact]
    public void MaxArea_IncreasingHeights_ReturnsCorrectArea()
    {
        var solution = new ContainerWithMostWater();
        int[] height = { 1, 2, 3, 4, 5 };

        int result = solution.MaxArea(height);

        Assert.Equal(6, result); // 3 x 2 = 6
    }

    [Fact]
    public void MaxArea_DecreasingHeights_ReturnsCorrectArea()
    {
        var solution = new ContainerWithMostWater();
        int[] height = { 5, 4, 3, 2, 1 };

        int result = solution.MaxArea(height);

        Assert.Equal(6, result); // 3 x 2 = 6
    }

    [Fact]
    public void MaxArea_TwoHeights_ReturnsAreaOfTwo()
    {
        var solution = new ContainerWithMostWater();
        int[] height = { 1, 5 };

        int result = solution.MaxArea(height);

        Assert.Equal(1, result); // 1 × 1 = 1
    }
}