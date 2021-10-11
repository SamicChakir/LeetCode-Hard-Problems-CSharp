using System;
using System.Collections.Generic;
using System.Text;
using System;


namespace LeetCodeHardProblems
{
    public static class GameOfLife
    {
        public static void GameOfLife1(int[][] board)
        {
            var nbLig = board.Length;
            var nbCol = board[0].Length;
            for (int i = 0; i < nbLig; i++)
            {
                for (int j = 0; j < nbCol; j++)
                {
                    board[i][j] = getTemporaryTransformationsUsingNeighbours(getNeighboursStates(board, i, j), board[i][j] == 1);
                }
            }

            MoveToNextState(board);
        }

        public static List<int> getNeighboursStates(int[][] board,int i, int j)
        {
            var nbLig = board.Length;
            var nbCol = board[0].Length;
            var neighboursStates = new List<int>();
            if (i > 0)
            {
                neighboursStates.Add(board[i - 1][j]);
                if (j > 0)
                {
                    neighboursStates.Add(board[i - 1][j - 1]);
                }
                if (j < nbCol - 1)
                {
                    neighboursStates.Add(board[i - 1][j + 1]);
                }
            }
            if ( i < nbLig - 1)
            {
                neighboursStates.Add(board[i + 1][j]);
                if (j > 0)
                {
                    neighboursStates.Add(board[i + 1][j - 1]);
                }
                if (j < nbCol - 1)
                {
                    neighboursStates.Add(board[i + 1][j + 1]);
                }
            }
            if ( j > 0)
            {
                neighboursStates.Add(board[i][j - 1]);
            }
            if ( j < nbCol - 1)
            {
                neighboursStates.Add(board[i][j + 1]);
            }
            return neighboursStates;

        }
        public static int getTemporaryTransformationsUsingNeighbours(List<int> neighboursStates, bool isCurrentAlive)
        {
            var aliveNeighboursCount = 0;
            var deadNeighboursCount = 0;
            foreach( var state in neighboursStates)
            {
                if ( isAlive(state) )
                {
                    aliveNeighboursCount += 1;
                }
                else
                {
                    deadNeighboursCount += 1;
                }
            }
            if (isCurrentAlive)
            {
                if (aliveNeighboursCount < 2)
                {
                    return TemporaryChange(1, false);
                }
                else if ( aliveNeighboursCount <= 3)
                {
                    return TemporaryChange(1, true);
                }
                else
                {
                    return TemporaryChange(1, false);
                }
            }
            else
            {
                if (aliveNeighboursCount == 3)
                {
                    return TemporaryChange(0, true);
                }
                return TemporaryChange(0, false);
            }
        }
        public static bool HasBeenChanged(int val)
        {
            return val > 2;
        }

        public static bool isAlive(int currentVal)
        {
            if (HasBeenChanged(currentVal))
            {
                currentVal = (currentVal >> 1) % 2;
            }
            return currentVal == 1;
        } 

        public static int TemporaryChange(int val,bool toAlive)
        {
            return 100 + 10 * val + (toAlive ? 1 : 0);
        }

        public static void MoveToNextState(int[][] board)
        {
            var nbLig = board.Length;
            var nbCol = board[0].Length;
            for (int i = 0; i < nbLig; i++)
            {
                for (int j = 0; j < nbCol; j++)
                {
                    board[i][j] = board[i][j] % 2;
                }
            }
        }

    }
}
