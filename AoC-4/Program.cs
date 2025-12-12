internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Users\Administrator\Documents\AoC2025\AoC-4\input.txt";
        int lineCount = File.ReadLines(path).Count();
        char[][] board = new char[lineCount][];
        for (int i = 0; i < lineCount; i++)
        {
            string line = File.ReadLines(path).Skip(i).First();
            char[] chars = line.ToCharArray();
            board[i] = chars;
        }
        int finalCount = 0;
        int countAvailable = 1;
        while (countAvailable != 0)
        {
            countAvailable = 0;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == '@' && isAccessible(j, i, board))
                    {
                        board[i][j] = 'X';
                        countAvailable++;
                    }
                }
            }
            finalCount += countAvailable;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        board[i][j] = '!';
                    }
                }
            }
        }    
        Console.WriteLine(finalCount);
    }

    private static bool isAccessible(int x, int y, char[][] board)
    {
        int maxX = board[y].Length;
        int maxY = board.Length;

        int countNeighbors = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                int newX = x + i;
                int newY = y + j;

                if (newX >= 0 && newX < maxX && newY >= 0 && newY < maxY)
                {
                    if (board[newY][newX] == '@' || board[newY][newX] == 'X')
                        countNeighbors++;
                }
            }
        }
        if (countNeighbors >= 4)
            return false;
        else   
            return true;
    }
}