using BattleshipLite.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library.Logic
{
    public class UserSetup
    {
        List<char> validLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E' };
        List<int> validNumbers = new List<int>() { 1, 2, 3, 4, 5 };
        public List<UserModel> CreateUsers()
        {
            UserModel userOne = new UserModel();
            UserModel userTwo = new UserModel();

            userOne.UserGrid = new List<GridModel>();
            userTwo.UserGrid = new List<GridModel>();

            List<UserModel> users = new List<UserModel>();
            users.Add(userOne);
            users.Add(userTwo);

            return users;
        }

        public void AskUsersName(List<UserModel> users)
        {
            int playerNumber = 1;
            foreach (UserModel user in users)
            {
                user.Name = ConsoleCommands.GetUserMessage($"Player {playerNumber} enter your name: ");
                playerNumber++;
            }
        }

        public void AssignUsersGrid(List<UserModel> users)
        {
            int number = 1;
            char letter = 'A';

            foreach (UserModel user in users)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        GridModel gridModel = new GridModel() { SpotLetter = letter, SpotNumber = number, Status = Status.Empty };
                        user.UserGrid.Add(gridModel);
                        letter++;
                    }
                    letter = 'A';
                    number++;
                }
            }

        }

        public void AssignShipLocations(List<UserModel> users)
        {
            char letter;
            int number;
            bool isValidLocation = false;

            foreach (UserModel user in users)
            {

                for (int i = 1; i <= 5; i++)
                {
                    do
                    {
                        isValidLocation = false;

                        Console.Clear();
                        Console.WriteLine("Choose spot on the grid for your ships in the range A1-E5\n");

                        Console.WriteLine($"Ship {i}: ");
                        do
                        {
                            char.TryParse(ConsoleCommands.GetUserMessage($"\rChoose a letter (A-E): "), out letter);
                        } while (!validLetters.Contains(char.ToUpper(letter)));

                        do
                        {
                            int.TryParse(ConsoleCommands.GetUserMessage($"Choose a number (1-5): "), out number);
                        } while (!validNumbers.Contains(number));

                        foreach (GridModel spot in user.UserGrid)
                        {
                            if (spot.SpotLetter == char.ToUpper(letter) && spot.SpotNumber == number && spot.Status == Status.Empty)
                            {
                                spot.Status = Status.Ship;
                                isValidLocation = true;
                                break;
                            }
                            else if (spot.SpotLetter == char.ToUpper(letter) && spot.SpotNumber == number && spot.Status == Status.Ship)
                            {
                                Console.WriteLine("There is already ship at this location. Try again!");
                            }

                            Console.WriteLine($"{spot.SpotLetter}{spot.SpotNumber}: {spot.Status}");
                        }
                    } while (!isValidLocation);

                }
            }
            
        }
    }
}
