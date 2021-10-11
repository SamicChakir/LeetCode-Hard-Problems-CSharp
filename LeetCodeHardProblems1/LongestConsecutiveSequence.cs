using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;


namespace LeetCodeHardProblems
{
    public static class LongestConsecutiveSequence
    {
        public static int LongestConsecutiveFunction(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            var min = nums.Min();
            var max = nums.Max();
            var valuesinNums = new HashSet<int>();
            var trackLeft = new HashSet<int>();
            foreach( var num in nums)
            {
                valuesinNums.Add(num);
                trackLeft.Add(num);
            }
            var maxSequenceSize = -1;

            var newSequence = true;
            var lastSequenceSize = 1;
            trackLeft.Remove(min);
            int i = min + 1;
            while ( i <= max)
            {
                if (valuesinNums.Contains(i))
                {
                    if (newSequence)
                    {
                        lastSequenceSize += 1;
                    }
                    else
                    {
                        //the begining of new sequence 
                        newSequence = true;
                        lastSequenceSize = 1;
                    }
                    trackLeft.Remove(i);
                    i++;
                }
                else
                {
                    if (newSequence)
                    {
                        //sequence has ended
                        newSequence = false;
                        if (lastSequenceSize > maxSequenceSize) maxSequenceSize = lastSequenceSize;
                        if ( trackLeft.Count != 0) i = trackLeft.Min();
                    }
                    else
                    {
                        i++;
                    }
                    

                }
                
            }
            if (newSequence)
            {
                if (lastSequenceSize > maxSequenceSize) maxSequenceSize = lastSequenceSize;
            }
            return maxSequenceSize;
        }

    }

    
}
