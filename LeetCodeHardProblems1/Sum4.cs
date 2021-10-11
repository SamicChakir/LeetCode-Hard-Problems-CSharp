using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHardProblems
{
    public static class Sum4
    {
        public static int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            var possibleSums1 = GetPossibleSums(nums1, nums2);
            var possibleSums2 = GetPossibleSums(nums3, nums4);
            var count = 0;
            foreach(var entry in possibleSums1)
            {
                if (possibleSums2.ContainsKey(-entry.Key))
                {
                    count += entry.Value * possibleSums2[-entry.Key];
                }
            }
            return count;
        }
        public static Dictionary<int,int> GetPossibleSums(int[] nums1, int[] nums2)
        {
            var possibleSums1 = new Dictionary<int, int>();

            foreach (var num1 in nums1)
            {
                foreach (var num2 in nums2)
                {
                    if (possibleSums1.ContainsKey(num1 + num2))
                    {
                        possibleSums1[num1 + num2] += 1;
                    }
                    else
                    {
                        possibleSums1[num1 + num2] = 1;
                    }
                }
            }
            return possibleSums1;
        }
}
}
