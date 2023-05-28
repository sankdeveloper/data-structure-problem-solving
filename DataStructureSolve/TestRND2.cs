namespace ConsoleApp1;

// https://leetcode.com/problems/sudoku-solver/
public class TestRND2
{
    public static void Main(string[] args)
    {
        string[][] board =
        {
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." },
            new[] { ".", ".", ".", ".", ".", ".", ".", ".", "." }
        };
        
        board[0][0] = new Random().Next(1, 9).ToString();
        board[8][8] = new Random().Next(1, 9).ToString();

        Console.WriteLine("Input");
        Print(board);
        SolveSudoku(board, 0, 0);
        Console.WriteLine("Output");
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