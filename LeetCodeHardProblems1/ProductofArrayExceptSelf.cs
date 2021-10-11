using System;

namespace LeetCodeHardProblems
{
    public static class ProductofArrayExceptSelf
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            var size = nums.Length;
            if ( size == 2)
            {
                return new int[] { nums[1], nums[0] };
            }
            var leftToRightProd = new int[size];
            var rightToLeftProd = new int[size];
            leftToRightProd[0] = nums[0];
            rightToLeftProd[size - 1] = nums[size - 1];

            for (int i = 1; i < size -1; i++)
            {
                leftToRightProd[i] = leftToRightProd[i - 1] * nums[i];
                rightToLeftProd[size - i - 1] = rightToLeftProd[size - i] * nums[size - i - 1]; 
            }
            leftToRightProd[size - 1] = leftToRightProd[size - 2] * nums[size -1];
            rightToLeftProd[0] = rightToLeftProd[1] * nums[0];

            var answer = new int[size];
            answer[0] = rightToLeftProd[1];
            answer[size - 1] = leftToRightProd[size - 2];
            for (int j = 1; j < size - 1; j++)
            {
                answer[j] = leftToRightProd[j - 1] * rightToLeftProd[j + 1];
            }
            return answer;
        }
    }
}
