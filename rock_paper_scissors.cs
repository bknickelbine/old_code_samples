using System; // Remove unused using directives inserted by Visual Studio

namespace RockPaperScissors
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Set the window title and print a greeting
            Console.Title = "Rock, Paper, Scissors";
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            //Declare variables for the user's choice and the CPU generated choice
            byte userChoice, cpuChoice;

            //Declare a string array to hold the choice names
            string[] choices = {"Rock", "Paper", "Scissors"};

            //Declare new random object
            var randy = new Random();

            //Loop sentinel initialization
            string doAgain = "yes";

            do //Begin indefinite program loop
            {
                //Set choice variables to 0 on each loop iteration
                userChoice = 0;
                cpuChoice = 0;

                //Prompt the user to enter their choice and store it in the userChoice variable
                Console.WriteLine("Which object do you choose? \n1. Rock\n2. Paper\n3. Scissors\n");
                userChoice = Convert.ToByte(Console.ReadLine()); //Convert the choice to a byte value

                //Convert the user's choice to an acceptable array value
                userChoice -= 1;

                //Prompt the user to re-enter a choice as long as they don't input a valid choice
                while (userChoice > 2)
                {
                    Console.WriteLine("Invalid selection, please enter a new choice!");
                    Console.WriteLine("Which object do you choose? \n1. Rock\n2. Paper\n3. Scissors\n");
                    userChoice = Convert.ToByte(Console.ReadLine()); //Convert the choice to a byte value
                }

                //Generate a new random number from 0-2
                cpuChoice = Convert.ToByte((randy.Next() % 3));

                //If the choices are the same, print tie condition message
                if (userChoice == cpuChoice)
                {
                    Console.WriteLine("You and the computer tied! You both chose {0}", choices[userChoice]);
                }

                //Otherwise if the user has won, print win condition message
                else if ((userChoice == 0 && cpuChoice == 2) || (userChoice == 1 && cpuChoice == 0) ||
                         (userChoice == 2 && cpuChoice == 1))
                {
                    Console.WriteLine("You won! You chose {0} and the computer chose {1}", choices[userChoice],
                                      choices[cpuChoice]);
                }

                //Otherwise the user lost, print lose condition message
                else
                {
                    Console.WriteLine("You lost! You chose {0} and the computer chose {1}", choices[userChoice],
                                      choices[cpuChoice]);
                }

                //Prompt the user to quit the program, read in their choice
                Console.WriteLine("\nDo you wish to play again? Press enter to play another game, or type quit");
                Console.ReadLine();
            } while (doAgain != "quit"); //If the user didn't type quit, repeat the game
        }
    }
}