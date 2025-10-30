using src.leetcode;

public class TwoSumTests
{
    
    // MethodName_TestScenario_ExpectedResult
    [Fact]
    public void solution_4digits_ShouldReturn0_1()
    {
        var solver  = new TwoSum();
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        
        Assert.Equal(new int[]{0, 1}, solver.solution(nums, target));
    }
    
    [Fact]
    public void solution_2Digits_ShouldReturn0_1()
    {
        var solver  = new TwoSum();
        int[] nums = { 3,3 };
        int target = 6;
        
        Assert.Equal(new int[]{0, 1}, solver.solution(nums, target));
    }
    
    [Fact]
    public void solution_1Digit_ShouldReturnNull()
    {
        var solver  = new TwoSum();
        int[] nums = { 3 };
        int target = 6;
        
        Assert.Equal(null, solver.solution(nums, target));
    }
    
}