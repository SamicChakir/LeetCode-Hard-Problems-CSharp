using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHardProblems
{
    public static class Helpers
    {
        public static string TransformArray(int[] array)
        {
            var size = array.Length;
            var resString = "";
            resString += "[";
            if (size == 0) return resString + "]";

            else if (size == 1) return resString + array[0].ToString() + "]";
            
            else
            {
                for(int i = 0; i < size - 1; i++)
                {
                    resString += array[i].ToString() + ",";
                }
                resString += array[size - 1] + "]";

            }
            return resString;
           
        }
    }
}
