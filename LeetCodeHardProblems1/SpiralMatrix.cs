using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeHardProblems
{
    public static class SpiralMatrix
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            var spiralOrder = new List<int>();
            var nbRows = matrix.Length;
            var nbCols = matrix[0].Length;
            if ( nbRows == 1)
            {
                for (int i = 0; i < nbCols; i++)
                {
                    spiralOrder.Add(matrix[0][i]);
                }
                return spiralOrder;
            }
            else if ( nbCols == 1)
            {
                for (int i = 0; i < nbRows; i++)
                {
                    spiralOrder.Add(matrix[i][0]);
                }
                return spiralOrder;
            }
            var rowLowerBound = 0;
            var rowUpperBound = nbRows -1;
            var colLowBound = 0;
            var ColUpperBound = nbCols - 1;

            while ( rowLowerBound < rowUpperBound && colLowBound < ColUpperBound)
            {
                //adding first row 
                for (int j = colLowBound; j <= ColUpperBound; j++)
                {
                    spiralOrder.Add(matrix[rowLowerBound][j]);
                }
                rowLowerBound += 1;

                //adding last col 
                for (int i = rowLowerBound; i <= rowUpperBound; i++)
                {
                    spiralOrder.Add(matrix[i][ColUpperBound]);
                }
                ColUpperBound -= 1;

                //adding last row 
                for (int j1 = ColUpperBound; j1 >= colLowBound; j1--)
                {
                    spiralOrder.Add(matrix[rowUpperBound][j1]);
                }
                rowUpperBound -= 1;

                //adding last col 
                for (int i1 = rowUpperBound; i1 >= rowLowerBound; i1--)
                {
                    spiralOrder.Add(matrix[i1][colLowBound]);
                }
                colLowBound += 1;
            }
            //in case one row left 
            if (rowLowerBound == rowUpperBound && colLowBound == ColUpperBound)
            {
                spiralOrder.Add(matrix[rowLowerBound][colLowBound]);
            }
            else if (rowLowerBound == rowUpperBound)
            {
                for (int l = colLowBound; l <= ColUpperBound; l++)
                {
                    spiralOrder.Add(matrix[rowLowerBound][l]);
                }
            }
            

            //in case one col left 
            else if (colLowBound == ColUpperBound)
            {
                for (int k = rowLowerBound; k <= rowUpperBound; k++)
                {
                    spiralOrder.Add(matrix[k][colLowBound]);
                }
            }
            

            return spiralOrder;
        }
    }
}
