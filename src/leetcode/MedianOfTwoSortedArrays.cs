namespace src.leetcode;

// 4. Median of Two Sorted Arrays
// (Hard)
//
// There are two sorted arrays nums1 and nums2 of size m and n respectively.
// Find the median of the two sorted arrays.
//
// The overall run time complexity should be O(log (m+n)).
//
// You may assume nums1 and nums2 cannot be both empty.
//
// Example 1:
//      nums1 = [1, 3]
//      nums2 = [2]
//      The median is 2.0
//
// Example 2:
//      nums1 = [1, 2]
//      nums2 = [3, 4]
//      The median is (2 + 3)/2 = 2.5
//
// Constraints:
//  - nums1.length == m
//  - nums2.length == n
//  - 0 <= m <= 1000
//  - 0 <= n <= 1000
//  - 1 <= m + n <= 2000
//  - -10^6 <= nums1[i], nums2[i] <= 10^6
public class MedianOfTwoSortedArrays
{
    public double solution(int[] nums1, int[] nums2)
    {
        // Always binary search on the shorter array to ensure O(log(min(m, n)))
        if (nums1.Length > nums2.Length)
        {
            return solution(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;

        // The total number of elements that need to be on the left side of the
        // partition
        int totalLeft = (m + n + 1) / 2;

        // Binary search boundaries for nums1
        int left = 0;
        int right = m;

        while (left <= right)
        {
            // Try cutting nums1 at index cut1
            int cut1 = (left + right) / 2;

            // The corresponding cut in nums2 to maintain totalLeft elements on
            // the left
            int cut2 = totalLeft - cut1;

            // Edge cases: handle out-of-bound cuts
            int L1 = (cut1 == 0) ? int.MinValue : nums1[cut1 - 1];
            int R1 = (cut1 == m) ? int.MaxValue : nums1[cut1];
            int L2 = (cut2 == 0) ? int.MinValue : nums2[cut2 - 1];
            int R2 = (cut2 == n) ? int.MaxValue : nums2[cut2];

            // Check if partition is valid
            if (L1 <= R2 && L2 <= R1)
            {
                if ((m + n) % 2 == 0)
                {
                    // Even total length: median is average of two middle values
                    return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0;
                }
                else
                {
                    // Odd total length: median is the max of left part
                    return Math.Max(L1, L2);
                }
            }
            else if (L1 > R2)
            {
                // L1 is too large, move to the left (cut1)
                right = cut1 - 1;
            }
            else
            {
                // L2 is too large, move to the right (cut1)
                left = cut1 + 1;
            }
        }

        // Control should never reach here if inputs are valid sorted arrays
        throw new ArgumentException("Input arrays are not sorted properly.");
    }
}