namespace TicTacToe
{
    public class Board
    {
        public int Length => board.Length;

        private char[,] board;

        public Board()
        {
            board = new char[3, 3]
            {
                { '1', '2', '3'},
                { '4', '5', '6'},
                { '7', '8', '9'}
            };
        }

        public void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"     ║     ║     \n" +
                              $"  {board[0, 0]}  ║  {board[0, 1]}  ║  {board[0, 2]}  \n" +
                              $"     ║     ║     \n" +
                              $"═════║═════║═════\n" +
                              $"     ║     ║     \n" +
                              $"  {board[1, 0]}  ║  {board[1, 1]}  ║  {board[1, 2]}  \n" +
                              $"     ║     ║     \n" +
                              $"═════║═════║═════\n" +
                              $"     ║     ║     \n" +
                              $"  {board[2, 0]}  ║  {board[2, 1]}  ║  {board[2, 2]}  \n" +
                              $"     ║     ║     \n");

            Console.ResetColor();
            Console.WriteLine();
        }

        public bool IsCellAvailable(int choice)
        {
            int row = (choice - 1) / 3;
            int col = (choice - 1) % 3;

            return board[row, col] != Program.PlayerFirst && board[row, col] != Program.PlayerSecond;
        }

        public void PlaceMarker(int choice, char currentPlayer)
        {
            int row = (choice - 1) / 3;
            int col = (choice - 1) % 3;
            board[row, col] = currentPlayer;
        }

        public bool CheckWin(char currentPlayer)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true;

                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true;
            }

            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            return false;
        }
        public bool CheckDraw()
        {
            foreach (var cell in board)
            {
                if (cell != Program.PlayerFirst && cell != Program.PlayerSecond)
                    return false;
            }

            return true;
        }
    }
}