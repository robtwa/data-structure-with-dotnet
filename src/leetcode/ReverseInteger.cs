namespace src.leetcode;

// 7. Reverse Integer
// (Medium)
//
// Given a signed 32-bit integer x, return x with its digits reversed.
// If reversing x causes the value to go outside the signed 32-bit integer
// range [-231, 231 - 1], then return 0.
// 
// Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
// 
// Example 1:
// Input: x = 123
// Output: 321
// ---
//
// Example 2:
// Input: x = -123
// Output: -321
// ---
//
// Example 3:
// Input: x = 120
// Output: 21
//  
// 
// Constraints:
// -2^31 <= x <= 2^31 - 1
public class ReverseInteger
{
    // The key to solving this problem lies in how to extract and remove the
    // last digit from the number in each iteration until the number becomes
    // zero.
    public int solution(int x) 
    {
        // Define a temp variable to store the reversed number
        long tmp = 0;

        // Keep extracting the last digit until x becomes 0
        while (x != 0)
        {
            // Extract the last digit and append it to tmp
            var last = x % 10;
            tmp = (tmp * 10) + last;

            // Remove the last digit from x
            x = x / 10;
        }

        // Check if tmp exceeds 32-bit signed integer range
        if (tmp > int.MaxValue || tmp < int.MinValue)
            return 0;

        // Return the reversed integer
        return (int) tmp;
    }
}