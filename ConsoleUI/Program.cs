using BattleshipLite.Library;
using BattleshipLite.Library.Logic;
using BattleshipLite.Library.Models;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConsoleCommands.StartGame();

            UserSetup userSetup = new UserSetup();

            List<UserModel> users = userSetup.CreateUsers();

            //UserModel userOne = new UserModel();
            //UserModel userTwo = new UserModel();
            //userOne.Name = UserInput("Player 1 enter your name: ");
            //userTwo.Name = UserInput("Player 2 enter your name: ");

            //userOne.UserGrid = new List<GridModel>();
            //userTwo.UserGrid = new List<GridModel>();

            userSetup.AskUsersName(users);


            userSetup.AssignUsersGrid(users);
            //int number = 1;
            //char letter = 'A';

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        userOne.UserGrid.Add(new GridModel() { SpotLetter = letter, SpotNumber = number, Status = Status.Empty });
            //        letter++;
            //    }
            //    letter = 'A';
            //    number++;
            //}

            userSetup.AssignShipLocations(users);

            foreach (UserModel user in users)
            {
                foreach (var spot in user.UserGrid)
                {
                    Console.WriteLine($"{spot.SpotLetter}{spot.SpotNumber}: {spot.Status}");
                }
            }


            //Console.WriteLine("Choose spot on the grid for your ships in the range A1-E5\n");
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine($"Ship {i}: ");
            //    char column = char.Parse(UserInput($"Choose a column (A-E): "));
            //    int row = int.Parse(UserInput($"Choose a row (1-5): "));
            //    foreach (GridModel spot in userOne.UserGrid)s
            //    {
            //        if (spot.SpotLetter == column && spot.SpotNumber == row)
            //        {
            //            spot.Status = Status.Ship;
            //        }
            //        Console.WriteLine($"{spot.SpotLetter}{spot.SpotNumber}: {spot.Status}");
            //    }
            //}

            

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
            Console.WriteLine("**  Welcome to Battleships Lite: a 2 player  **\n" +
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