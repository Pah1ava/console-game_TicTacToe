namespace TicTacToe
{
    internal class Messages
    {
        public static void DisplayWelcomeMessage()
        {

        }

        public static void DisplayWinMessage(char currentPlayer)
        {
            Console.Clear();
            string winMessage = File.ReadAllText("Win.txt");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(winMessage);
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void DisplayDrawMessage()
        {
            Console.Clear();
            string drawMessage = File.ReadAllText("Draw.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(drawMessage);
            Console.ResetColor();
        }
    }
}
