using src.Models;

public class ArrayStackTests
{
    [Fact]
    public void Push_ShouldIncreaseSize()
    {
        var stack = new ArrayStack<int>(5);
        stack.Push(10);
        stack.Push(20);

        Assert.Equal(2, stack.Size());
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Pop_ShouldReturnLastInsertedElement()
    {
        var stack = new ArrayStack<int>(3);
        stack.Push(5);
        stack.Push(10);

        int result = stack.Pop();

        Assert.Equal(10, result);
        Assert.Equal(1, stack.Size());
    }

    [Fact]
    public void Peek_ShouldReturnTopWithoutRemoving()
    {
        var stack = new ArrayStack<string>(3);
        stack.Push("A");
        stack.Push("B");

        string top = stack.Peek();

        Assert.Equal("B", top);
        Assert.Equal(2, stack.Size());
    }

    [Fact]
    public void Pop_OnEmptyStack_ShouldThrowException()
    {
        var stack = new ArrayStack<int>(3);

        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_OnEmptyStack_ShouldThrowException()
    {
        var stack = new ArrayStack<int>(3);

        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }


    [Fact]
    public void Push_ShouldDoubleCapacity_WhenFull()
    {
        var stack = new ArrayStack<int>(2);

        stack.Push(1);
        stack.Push(2);
        Assert.True(stack.IsFull()); // capacity doubled

        stack.Push(3); // should trigger resize
        Assert.Equal(3, stack.Size());

        stack.Push(4);
        Assert.Equal(4, stack.Size());
    }


    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenStackEmpty()
    {
        var stack = new ArrayStack<int>(5);

        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsFull_ShouldReturnTrue_WhenStackAtCapacity()
    {
        var stack = new ArrayStack<int>(2);
        stack.Push(1);
        stack.Push(2);

        Assert.True(stack.IsFull());
    }

    [Fact]
    public void Size_ShouldReturnCorrectCount_AfterMultipleOperations()
    {
        var stack = new ArrayStack<int>(5);
        stack.Push(1);
        stack.Push(2);
        stack.Pop();
        stack.Push(3);
        stack.Push(4);

        Assert.Equal(3, stack.Size());
    }

    [Fact]
    public void AddPeekNext_ManyNumbers_ShouldMaintainCorrectStructure()
    {
        bool completed = Task.Run(() =>
        {
            var studentStack = new ArrayStack<int>();

            // Add numbers 0 - 999 (inclusive) to the stack
            for (int i = 0; i < 1000; i++)
            {
                // Add the number
                studentStack.Push(i);

                // Check if the top of the stack is the correct number
                Assert.Equal(i, studentStack.Peek());

                // Check if the stack is not empty
                Assert.False(studentStack.IsEmpty());

                // Check if the size is correct
                Assert.Equal(i + 1, studentStack.Size());
            }

            // Empty out the stack
            for (int i = 999; i >= 0; i--)
            {
                // Stack should not be empty
                Assert.False(studentStack.IsEmpty());

                // Top element should be correct
                Assert.Equal(i, studentStack.Peek());

                // Popped element should match expected
                Assert.Equal(i, studentStack.Pop());

                // Size should match after popping
                Assert.Equal(i, studentStack.Size());
            }

            // Finally stack should be empty
            Assert.True(studentStack.IsEmpty());
        }).Wait(TimeSpan.FromMilliseconds(3000));

        Assert.True(completed, "Test exceeded 3-second limit.");
    }
}