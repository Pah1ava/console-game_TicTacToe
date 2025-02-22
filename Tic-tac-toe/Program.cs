namespace TicTacToe
{
    class Program
    {
        public const char PlayerFirst = 'X';
        public const char PlayerSecond = 'O';

        static char currentPlayer = PlayerFirst;
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static public void ShowMenu()
        {
            const string PlayCommand = "1";
            const string ExitCommand = "2";

            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Messages.DisplayWelcomeMessage();

                Console.WriteLine($"{PlayCommand} - PLAY \n" +
                                  $"{ExitCommand} - EXIT \n");

                Console.Write("COMMAND: ");
                string userInput = Console.ReadLine();

                if (userInput == PlayCommand)
                {
                    Console.Clear();
                    StartGame();

                    break;
                }
                else if (userInput == ExitCommand)
                {
                    Console.Clear();
                    Console.Write("EXIT...");
                    Thread.Sleep(1000);

                    isWorking = false;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NOT CORRECT!");
                    Console.ResetColor();
                    Thread.Sleep(800);

                    Console.Clear();
                }
            }
        }

        static void StartGame()
        {
            Board board = new Board();

            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                board.DrawBoard();

                GetPlayerInput(board);

                if (board.CheckWin(currentPlayer))
                {
                    Console.Clear();
                    board.DrawBoard();

                    Messages.DisplayWinMessage(currentPlayer);
                    ShowMenu();

                    break;
                }
                if (board.CheckDraw())
                {
                    Console.Clear();
                    board.DrawBoard();

                    Messages.DisplayDrawMessage();
                    break;
                }

                SwichPlayer();
            }
        }

        public static void SetPlayerColor(char currentPlayer)
        {
            if (currentPlayer == PlayerFirst)
                Console.ForegroundColor = ConsoleColor.Magenta;
            else if (currentPlayer == PlayerSecond)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ResetColor();
        }

        public static void GetPlayerInput(Board board)
        {

            SetPlayerColor(currentPlayer);
            int choice;
            Console.Write($"PLAYER {currentPlayer}. YOUR CHOICE (1-{board.Length}): ");
            Console.ResetColor();

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > board.Length || !board.IsCellAvailable(choice))
            {
                Console.WriteLine("NOT CORRECT!");
            }

            board.PlaceMarker(choice, currentPlayer);
        }

        public static void SwichPlayer()
        {
            currentPlayer = (currentPlayer == PlayerFirst) ? PlayerSecond : PlayerFirst;
        }
    }
}