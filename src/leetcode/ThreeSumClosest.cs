namespace src.leetcode;

// 16. 3 Sum Closest
// (Medium)
// Given an integer array nums of length n and an integer target, find three
// integers in nums such that the sum is closest to target.
// 
// Return the sum of the three integers.
// 
// You may assume that each input would have exactly one solver.
//  
// 
// Example 1:
// 
// Input: nums = [-1,2,1,-4], target = 1
// Output: 2
// Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
// ---
//
// Example 2:
// 
// Input: nums = [0,0,0], target = 1
// Output: 0
// Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).
// --- 
// 
// Constraints:
// 
// 3 <= nums.length <= 500
// -1000 <= nums[i] <= 1000
// -104 <= target <= 104
public class ThreeSumClosest
{
    // O(n^2)
    // This problem is solved using the two-pointer narrowing method.
    // First, sort the array.
    // Then, `i` scans from the beginning to the end.
    //
    // Here, we also need to be careful about the issue of duplicate numbers in
    // the array. There are many ways to handle this; we can use a map to count
    // and remove duplicates. Here, I use a simple approach: while looping,
    // `i` is compared with the previous number. If they are equal, `i`
    // continues to move forward until it reaches the next position where the
    // number is different from the previous one.
    //
    // The two pointers, `j` and `k`, then squeeze the array. `j` is the next
    // number after `i`, and `k` is the last number in the array.
    // Since the array is sorted, `k` is the largest. `j` moves forward, and
    // `k` moves backward, gradually squeezing out the value closest to the
    // target.
    public int solution(int[] nums, int target)
    {
        int n = nums.Length;

        // Initialize result and minimum difference
        int res = 0;
        int diff = int.MaxValue;

        if (n > 2)
        {
            // Sort the array to use two-pointer technique
            Array.Sort(nums);

            // Fix one number and use two pointers for the remaining array
            for (int i = 0; i < n - 2; i++)
            {
                int j = i + 1;       // left pointer
                int k = n - 1;       // right pointer

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int currentDiff = Math.Abs(sum - target);
                    if (currentDiff < diff)
                    {
                        // Update best result if closer to target
                        diff = currentDiff;
                        res = sum;
                    }
                    
                    if (sum == target)
                        return res; // Perfect match found, return immediately
                    
                    if (sum > target)
                        k--; // The sum is too large, move right pointer left
                    else
                        j++; // The sum is too small, move left pointer right
                }
            }
        }

        // Return the sum closest to target
        return res;
    }
}