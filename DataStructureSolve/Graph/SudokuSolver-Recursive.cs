namespace ConsoleApp1.Graph;

// https://leetcode.com/problems/sudoku-solver/
public class SudokuSolverRecursive
{
    public static void Main1(string[] args)
    {
        string[][] board =
        {
            new[] { "5", "3", ".", ".", "7", ".", ".", ".", "." },
            new[] { "6", ".", ".", "1", "9", "5", ".", ".", "." },
            new[] { ".", "9", "8", ".", ".", ".", ".", "6", "." },
            new[] { "8", ".", ".", ".", "6", ".", ".", ".", "3" },
            new[] { "4", ".", ".", "8", ".", "3", ".", ".", "1" },
            new[] { "7", ".", ".", ".", "2", ".", ".", ".", "6" },
            new[] { ".", "6", ".", ".", ".", ".", "2", "8", "." },
            new[] { ".", ".", ".", "4", "1", "9", ".", ".", "5" },
            new[] { ".", ".", ".", ".", "8", ".", ".", "7", "9" }
        };

        SolveSudoku(board, 0, 0);
        Print(board);
        Console.ReadKey();
    }

    private static bool SolveSudoku(string[][] board, int row, int col)
    {
        if (row == 9) return true;
        // if (row >= 9 || col >= 9) return false;

        int nextR = 0, nextC = 0;
        if (col == 8)
        {
            nextR = row + 1;
            nextC = 0;
        }
        else
        {
            nextR = row;
            nextC = col + 1;
        }

        if (board[row][col] != ".") // is 'number available' at current cell, then: go to next cell and try further.
        {
            if (SolveSudoku(board, nextR, nextC))
            {
                return true;
            }
        }
        else // is '.' available, then try putting numbers from 1 t0 9.
        {
            for (int number = 1; number <= 9; number++)
            {
                if (IfFit(board, row, col, number.ToString())) // check validity
                {
                    // put number if valid, and try-solve for next cell
                    board[row][col] = number.ToString();
                    if (SolveSudoku(board, nextR, nextC))
                    {
                        return true;
                    }

                    // coming to this line means, solution not found: backtrack and revert to original '.'
                    board[row][col] = ".";
                }
            }
        }

        return false;
    }

    private static bool IfFit(string[][] board, int row, int col, string number)
    {
        //check in that specific cell, horizontally and vertically
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == number) return false;
            if (board[i][col] == number) return false;
        }

        //check in curusponding 3*3 matrix
        int startRow = row - row % 3;
        int startCol = col - col % 3;
        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (board[i][j] == number) return false;
            }
        }

        return true;
    }

    private static void Print(string[][] board)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                Console.Write(board[row][col] + " ");
            }

            Console.WriteLine();
        }
    }
}

/*
 OUTPUT:
5 3 4 6 7 8 9 1 2
6 7 2 1 9 5 3 4 8
1 9 8 3 4 2 5 6 7
8 5 9 7 6 1 4 2 3
4 2 6 8 5 3 7 9 1
7 1 3 9 2 4 8 5 6
9 6 1 5 3 7 2 8 4
2 8 7 4 1 9 6 3 5
3 4 5 2 8 6 1 7 9
 */