namespace src.leetcode;

// 2. Add Two Numbers
// (Medium)
// You are given two non-empty linked lists representing two non-negative
// integers. The digits are stored in reverse order, and each of their nodes
// contains a single digit. Add the two numbers and return the sum as a
// linked list.
// 
// You may assume the two numbers do not contain any leading zero, except
// the number 0 itself.
// 
// Example 1:
// Input: l1 = [9,9], l2 = [1]
// Output: [0,0,1]
// ---
//
// Example 2:
// Input: l1 = [2,4,3], l2 = [5,6,4]
// Output: [7,0,8]
// Explanation: 342 + 465 = 807.
// --
//
// Example 3:
// Input: l1 = [0], l2 = [0]
// Output: [0]
// --
//
// Constraints:
// 
// The number of nodes in each linked list is in the range [1, 100].
// 0 <= Node.val <= 9
// It is guaranteed that the list represents a number that does not have
// leading zeros.

public class ListNode
{
    public int Val;
    public ListNode Next;

    public ListNode(int val = 0, ListNode next = null)
    {
        Val = val;
        Next = next;
    }
}

public class AddTwoNums
{
    // Logic Algorithm Idea
    // 1. Create a dummy head node for easy result return;
    //    - head := &ListNode{Val:0}
    //    - The current pointer is used to construct the new linked list;
    // 2. Set a carry variable carry = 0
    // 3. Loop until both linked lists are empty:
    //    - Get the value x and y of the current node (0 if the node is empty);
    //    - Calculate sum = x + y + carry
    //    - The current value is sum % 10
    //    - The new carry is sum / 10
    // 4. Add the current value to the result linked list;
    // 5. Finally, if carry > 0, add another node;
    // 6. Return head.Next (skip the dummy head node)
    public ListNode solution(ListNode l1, ListNode l2)
    {
        if (l1 == null || l2 == null)
            return null;

        // Create a dummy head
        var head = new ListNode(0);
        var current = head;
        int carry = 0;

        // Loop until both linked lists are empty:
        while (l1 != null || l2 != null)
        {
            // Get the value x and y of the current node (0 if the node is
            // empty);
            int x = (l1 != null) ? l1.Val : 0;
            int y = (l2 != null) ? l2.Val : 0;

            int sum = x + y + carry;
            carry = sum / 10; // ex. carry = (9 + 9 + 1) / 10 = 1
            int remain = sum % 10;
            
            // Add the current value to the result linked list;
            current.Next = new ListNode(remain);
            current = current.Next;

            // Moving forward
            if (l1 != null) l1 = l1.Next;
            if (l2 != null) l2 = l2.Next;
        }
        
        // Finally, if carry > 0, add another node;
        if (carry > 0)
            current.Next = new ListNode(carry);

        return head.Next; // Skip dummy head node
    }
}


