namespace src.leetcode;

// 9. Palindrome Number
// (Easy)
//
// Given an integer x, return true if x is a palindrome, and false otherwise.
// 
// Example 1:
// 
// Input: x = 121
// Output: true
// Explanation: 121 reads as 121 from left to right and from right to left.
// ---
//
// Example 2:
// 
// Input: x = -121
// Output: false
// Explanation: From left to right, it reads -121. From right to left,
// it becomes 121-. Therefore it is not a palindrome.
// ---
//
// Example 3:
// 
// Input: x = 10
// Output: false
// Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
//  
// 
// Constraints:
// 
// -231 <= x <= 231 - 1
// 
public class PalindromeNumber
{
    public bool solution(int x)
    {
        // Negative numbers cannot be palindromes
        if (x < 0)
            return false;

        // Single-digit numbers are always palindromes
        if (x < 10)
            return true;

        // Convert the integer to a string
        string s = x.ToString();
        int length = s.Length;

        // Compare characters from both ends toward the center
        for (int i = 0; i < length / 2; i++)
        {
            if (s[i] != s[length - 1 - i])
                return false;
        }

        // All characters match → it is a palindrome
        return true;
    }
}