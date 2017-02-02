using System;

//Remove unused using directives inserted by visual studio

namespace MultiplicationTable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Simple Multiplication Table"; //Set the console window title
            Console.Write("Welcome to the Simple Multiplication Table!" + "\n\n     "); //Print a welcome message to the user

            //Print the upper row of numbers
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("{0,5}", i); //Print the current value of the iterator to the screen
            }

            //Print a line separator
            Console.WriteLine("\n_________________________________________________________");

            //Print the bottom portion of the multiplication table
            for (int i = 1; i <= 10; i++) //Print 10 lines of the multiplication table
            {
                Console.Write("{0,5}", i); //Print the leftmost column of numbers
                for (int j = 1; j <= 10; j++) //Print the 10 multiplied numbers into the table
                {
                    Console.Write("{0,5}", (j*i)); //Print multiplied number
                }
                Console.Write("\n"); //Print new line for next line of multiplication table
            }
            Console.Read(); //Stop program from terminating prematurely
        }
    }
}