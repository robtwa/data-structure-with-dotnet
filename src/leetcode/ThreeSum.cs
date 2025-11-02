namespace src.leetcode;

// 15.3Sum
// (Medium)
//
// Given an integer array nums, return all the triplets
// [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k,
// and nums[i] + nums[j] + nums[k] == 0.
// 
// Notice that the solution set must not contain duplicate triplets.
// 
// Example 1:
// 
// Input: nums = [-1,0,1,2,-1,-4]
// Output: [[-1,-1,2],[-1,0,1]]
// Explanation: 
// nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
// nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
// nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
// The distinct triplets are [-1,0,1] and [-1,-1,2].
// Notice that the order of the output and the order of the triplets does not matter.
// ---
//
// Example 2:
// 
// Input: nums = [0,1,1]
// Output: []
// Explanation: The only possible triplet does not sum up to 0.
// ---
//
// Example 3:
// 
// Input: nums = [0,0,0]
// Output: [[0,0,0]]
// Explanation: The only possible triplet sums up to 0.
// --- 
// 
// Constraints:
// 
// 3 <= nums.length <= 3000
// -105 <= nums[i] <= 105
public class ThreeSum
{   
    // Algorithm Idea
    // A brute-force approach would check every triplet (a, b, c) → O(n³),
    // which is too slow.
    // 
    // Use a map to store the frequency of each number.
    // Then for every pair (a, b), check whether c = -(a + b) exists in the map.
    // 
    // To avoid duplicates:
    //  - Count occurrences via a map;
    //  - Extract and sort unique keys;
    //  - Iterate through (a, b) pairs;
    //  - Find c = -(a + b) in map;
    //  - Only accept results where a ≤ b ≤ c to ensure uniqueness.
    public IList<IList<int>> solution(int[] nums)
    {
        var res = new List<IList<int>>(); 
        var counter = new Dictionary<int, int>();  

        // Count the occurrences of each number
        foreach (var value in nums)
        {
            // if value does not in counter, then add {value, 1}
            // otherwise, increase 1.
            if (!counter.TryAdd(value, 1)) 
                counter[value]++;
        }

        // Get unique numbers and sort them
        var uniqNums = counter.Keys.ToList();
        uniqNums.Sort();

        // Traversing unique number combinations
        for (int i = 0; i < uniqNums.Count; i++)
        {
            int a = uniqNums[i];

            // Case 1: Three identical numbers 
            // Example: [0,0,0]
            if (a * 3 == 0 && counter[a] >= 3)
            {
                res.Add(new List<int> { a, a, a });
            }

            for (int j = i + 1; j < uniqNums.Count; j++)
            {
                int b = uniqNums[j];
                
                // Case 2: Two identical numbers + one different number
                // (a, a, b)
                if (a * 2 + b == 0 && counter[a] > 1)
                    res.Add(new List<int> { a, a, b });
                // (a, b, b)
                if (a + b * 2 == 0 && counter[b] > 1)
                    res.Add(new List<int> { a, b, b });

                // Case 3: Three distinct numbers
                // (a, b, c)
                int c = -(a + b);
                if (c > b && counter.ContainsKey(c))
                {
                    // This is the key technique for removing duplicates.
                    // Because the sum of three numbers [a, b, c] is not
                    // order-sensitive, for example, [-1, 0, 1], [1, 0, -1], and
                    // [0, -1, 1] are all the same combination.
                    // To avoid repetition, we enforce the order:
                    // a < b < c
                    res.Add(new List<int> { a, b, c });
                }
            }
        }

        return res;
    }
}