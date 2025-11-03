using src.leetcode;

namespace unitTests;

public class ThreeSumClosestTests
{
    [Fact]
    public void ThreeSumClosest_NormalCase_ReturnsClosestSum()
    {
        var solver = new ThreeSumClosest();
        int[] nums = { -1, 2, 1, -4 };
        int target = 1;

        int result = solver.solution(nums, target);

        Assert.Equal(2, result); // 期望最接近 1 的和是 2
    }

    [Fact]
    public void ThreeSumClosest_ExactMatch_ReturnsTarget()
    {
        var solver = new ThreeSumClosest();
        int[] nums = { 0, 1, 2 };
        int target = 3;

        int result = solver.solution(nums, target);

        Assert.Equal(3, result); // 存在组合 (0,1,2)=3
    }

    [Fact]
    public void ThreeSumClosest_AllSameNumbers_ReturnsTriple()
    {
        var solver = new ThreeSumClosest();
        int[] nums = { 2, 2, 2, 2 };
        int target = 10;

        int result = solver.solution(nums, target);

        Assert.Equal(6, result); // 2+2+2=6
    }

    [Fact]
    public void ThreeSumClosest_MixedNumbers_ReturnsClosestSum()
    {
        var solver = new ThreeSumClosest();
        int[] nums = { -2, 0, 1, 3 };
        int target = 2;

        int result = solver.solution(nums, target);

        Assert.Equal(2, result); // (-2,1,3)=2
    }

    [Fact]
    public void ThreeSumClosest_ThreeElements_ReturnsTheirSum()
    {
        var solver = new ThreeSumClosest();
        int[] nums = { 1, 2, 3 };
        int target = 5;

        int result = solver.solution(nums, target);

        Assert.Equal(6, result); // 唯一组合 (1,2,3)=6
    }
}