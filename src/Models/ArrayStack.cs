namespace src.Models;

// Generic stack implementation using an array
public class ArrayStack<T>
{
    private T[] stackArray;   // internal array
    private int top;          // index of the top element
    private int capacity;     // maximum capacity

    // Constructor
    public ArrayStack(int capacity = 10)
    {
        this.capacity = capacity;
        stackArray = new T[capacity];
        top = -1;
    }

    // Push an element onto the stack
    public void Push(T item)
    {
        if (IsFull())
            DoubleCapacity();
        
        stackArray[++top] = item;
    }

    // Pop the top element from the stack
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");
        
        return stackArray[top--];
    }

    // Peek the top element without removing it
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");
        
        return stackArray[top];
    }

    // Check if the stack is empty
    public bool IsEmpty()
    {
        return top == -1;
    }

    // Check if the stack is full
    public bool IsFull()
    {
        return top == capacity - 1;
    }

    // Get the current size
    public int Size()
    {
        return top + 1;
    }
    
    ////////////////////////////////////////////////////////////////////////////
    // helpers
    ////////////////////////////////////////////////////////////////////////////
    private void DoubleCapacity()
    {
        int newCapacity = capacity * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(stackArray, newArray, capacity);
        stackArray = newArray;
        capacity = newCapacity;
    }

    // Print all elements (for testing)
    public void PrintStack()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        Console.Write("Stack contents (top → bottom): ");
        for (int i = top; i >= 0; i--)
            Console.Write(stackArray[i] + " ");
        Console.WriteLine();
    }
}

