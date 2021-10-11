using System;
using System.Collections.Generic;
using System.Text;
using System;


namespace LeetCodeHardProblems
{
    public static class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            var volume = 0;
            MaxAreaRecursive(height, 0, height.Length - 1,ref volume);
            return volume;
        }

        public static void MaxAreaRecursive(int[] height,int low, int high, ref int volume)
        {
            if (low < high)
            {
                var highVal = height[high];
                for (int i = low; i < high; i++)
                {
                    volume = Math.Max(volume, (high - i) * Math.Min(height[i], highVal));
                }
                MaxAreaRecursive(height, low, high - 1, ref volume);
            }
            
        }
    }
}
