namespace src.leetcode;

public class TwoSum
{
    // 1. Two Sum
    // Hint
    // Given an array of integers nums and an integer target, return indices of
    // the two numbers such that they add up to target.
    // 
    // You may assume that each input would have exactly one solution, and you
    // may not use the same element twice.
    // 
    // You can return the answer in any order.
    // 
    // Example 1:
    // 
    // Input: nums = [2,7,11,15], target = 9
    // Output: [0,1]
    // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    // Example 2:
    // 
    // Input: nums = [3,2,4], target = 6
    // Output: [1,2]
    // Example 3:
    // 
    // Input: nums = [3,3], target = 6
    // Output: [0,1]
    //  
    // 
    // Constraints:
    // 
    // 2 <= nums.length <= 104
    // -109 <= nums[i] <= 109
    // -109 <= target <= 109
    // Only one valid answer exists.
    
    // Scan the array sequentially, and for each element, find the other half
    // of the number that can be combined with the given value in the map.
    // If found, directly return the subscripts of the two numbers.
    // If not found, store the number in the map, wait until the "other half"
    // number is scanned, then take it out and return the result.
    public int[] solution(int[] nums, int target)
    {
        // Create a dict with number as key and index as val
        var dict = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int complement =  target - nums[i];

            if (dict.ContainsKey(complement))
            {
                return [dict[complement], i];
            }
            
            // put the current number to the dict
            dict[nums[i]] = i;
        }


        return null;
    }
}