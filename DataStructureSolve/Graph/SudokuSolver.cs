namespace ConsoleApp1.Graph;

// https://leetcode.com/problems/sudoku-solver/
public class SudokuSolver
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

        SolveSudoku(board);
        Print(board);
        Console.ReadKey();
    }

    private static bool SolveSudoku(string[][] board)
    {
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] != ".") continue;
                for (int number = 1; number <= 9; number++)
                {
                    if (IfFit(board, row, col, number.ToString()))
                    {
                        board[row][col] = number.ToString();
                        if (SolveSudoku(board))
                            return true;
                        else
                            board[row][col] = ".";
                    }
                }

                //none of the number 1 to 9 fit, there no possible solution. fails to solve
                return false;
            }
        }

        //we reached filling till the end of the cell, and probabily we got the solution.
        return true;
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