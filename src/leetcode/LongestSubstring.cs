namespace src.leetcode;

// 3. Longest Substring Without Repeating Characters (med.)
//
// Given a string, find the length of the longest substring without repeating
// characters.
// 
// Example 1:
// 
// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3. Note that "bca" and
// "cab" are also correct answers.
// ---
// Example 2:
// 
// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.
// ---
// Example 3:
// 
// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not
// a substring.
// ---
// 
// Constraints:
// 
// 0 <= s.length <= 5 * 104
// s consists of English letters, digits, symbols and spaces.
public class LongestSubstring
{   
    // Algorithm Logic (Sliding Window)
    // 1. The right pointer continuously moves to the right, expanding the
    //    window;
    // 2. If the current character has not appeared before (freq[c] == 0), the
    //    window expands to the right;
    // 3. If the character is repeated, the left pointer moves to the right
    //    (shrinking the window);
    // 4. Update the maximum window length result in each loop;
    // 5. The loop ends when left reaches the end of the string.
    public int solution(string s)
    {
        // Handle null or empty string case
        if (s == null || s.Length == 0) {
            return 0;
        }

        int[] freq = new int[256]; // Frequency array for all ASCII characters
        int result = 0;            // Stores the maximum length found so far
        int left = 0, right = -1;  // Initialize the sliding window [left, right]

        // Move the sliding window while the left pointer is within the string bounds
        while (left < s.Length) {
            // Try to expand the window by moving the right pointer if:
            //  1. the right hand side is less than the string length
            //  and 
            //  2. the next character has not appeared in the current window
            if (right + 1 < s.Length && freq[s[right + 1]] == 0) 
            {
                freq[s[++right]]++; // Include the character and move right
            } 
            // Otherwise, shrink the window from the left to remove duplicates
            else 
            {
                freq[s[left++]]--;
            }

            // Update result with the current window size
            result = Math.Max(result, right - left + 1);

            // Debug output showing the current window state
            Console.WriteLine(s + ":" 
                                + " result:" + result
                                + ", left: " + left
                                + ", right: " + right
                                + ", sliding window: " + s.Substring(left, right - left + 1));
        }

        return result;
    }
}