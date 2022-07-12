namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StartGame();

            Console.ReadLine();
        }
        public static void StartGame()
        {
            string startGame = "";
            do
            {
                WelcomeScreen();
                startGame = UserInput("");
                Console.Clear();
            } while (startGame.ToLower() != "start");
        }

        public static void WelcomeScreen()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("**   Welcome to BattleshipsLite: a 2 player  **\n" +
                              "**   game where players take turns to sink   **\n" +
                              "**           each others ships!!!            **");
            Console.WriteLine("***********************************************");
            Console.WriteLine("** Rules:                                    **\n" +
                              "**                                           **\n" +
                              "** 1. Grid is in range A1-E5                 **\n" +
                              "** 2. Each player chooses 5 spots for ships  **\n" +
                              "**    2.1. One ship per spot                 **\n" +
                              "** 3. Players take turns to fire with ships  **\n" +
                              "**    3.1. Can't shoot at the same place     **\n" +
                              "**         twice                             **\n" +
                              "** 4. Type 'exit' to stop playing            **\n" +
                              "**                                           **\n" +
                              "**                                           **\n" +
                              "**                                           **");
            Console.WriteLine("**    (Type 'start' to start the game)       **");
            Console.WriteLine("***********************************************");
        }

        public static string UserInput(string message)
        {
            Console.Write(message);
            string output = Console.ReadLine();

            if (output.ToLower() == "exit")
            {
               ExitApplication();
               return null;
            }
            else
            {
               return output;
            }

        }

        public static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}