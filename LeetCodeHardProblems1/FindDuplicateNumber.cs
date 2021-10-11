using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;


namespace LeetCodeHardProblems
{
    public static class FindDuplicateNumber 
    {
        public static int FindDuplicate(int[] nums)
        {
            int n = nums.Length - 1;
            int i = 0;
            while ( i <= n)
            {
                if (nums[i] == i+1)
                {
                    i++;
                    continue;
                }
                else
                {
                    var valatRealPosition = nums[nums[i] - 1];
                    if (valatRealPosition == nums[i])
                    {
                        return valatRealPosition;
                    }
                    else
                    {
                        nums[nums[i] - 1] = nums[i];
                        nums[i] = valatRealPosition;
                    }
                }
            }
            return 0;
        }
    }

    
}
