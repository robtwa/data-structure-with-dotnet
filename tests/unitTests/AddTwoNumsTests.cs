using src.leetcode;

namespace unitTests;

public class AddTwoNumsTests
{
    // MethodName_TestScenario_ExpectedResult
    private ListNode BuildList(int[] values)
    {
        var dummy = new ListNode(0);
        var current = dummy;
        foreach (var v in values)
        {
            current.Next = new ListNode(v);
            current = current.Next;
        }
        return dummy.Next;
    }

    private int[] ToArray(ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.Val);
            node = node.Next;
        }
        return list.ToArray();
    }

    [Fact]
    public void AddTwoNums_SameLengthWithoutCarry_ReturnsCorrectSum()
    {
        var solver = new AddTwoNums();

        // Input: [2,4,3] + [5,6,4]
        var l1 = BuildList(new int[] { 2, 4, 3 });
        var l2 = BuildList(new int[] { 5, 6, 4 });

        var result = solver.solution(l1, l2);
        var resultArray = ToArray(result);

        Assert.Equal(new int[] { 7, 0, 8 }, resultArray); // 342 + 465 = 807
    }
    
    [Fact]
    public void AddTwoNums_AllZero_RetrunsZero()
    {
        var solver = new AddTwoNums();
        var l1 = BuildList(new int[] { 0 });
        var l2 = BuildList(new int[] { 0 });

        var result = solver.solution(l1, l2);
        var resultArray = ToArray(result);

        Assert.Equal(new int[] { 0 }, resultArray); // 0 + 0 =0
    }

    [Fact]
    public void AddTwoNums_LastDigitCarry_AddsExtraNode()
    {
        var solver = new AddTwoNums();
        var l1 = BuildList(new int[] { 9, 9, 9 });
        var l2 = BuildList(new int[] { 1 });

        var result = solver.solution(l1, l2);
        var resultArray = ToArray(result);

        Assert.Equal(new int[] { 0, 0, 0, 1 }, resultArray); // 999 + 1 = 1000
    }
}