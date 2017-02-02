using System;

//Remove unused using directives inserted by Visual Studio

namespace Numbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Prompt the user to enter the first number to be operated on
            Console.Write("Please enter the first number: ");
            //Convert the entry to an integer and store it in the term1 value
            int term1 = Convert.ToInt32(Console.ReadLine());

            //Prompt the user to enter the second number to be operated on
            Console.Write("Please enter the second number: ");
            //Convert the entry to an integer and store it in the term2 value
            int term2 = Convert.ToInt32(Console.ReadLine());

            //Print a new line for aesthetics
            Console.WriteLine();

            //Call the Sum function and pass the two terms by reference
            Sum(ref term1, ref term2);
            //Call the Difference function and pass the two terms by reference
            Difference(ref term1, ref term2);
            //Call the Product function and pass the two terms by reference
            Console.WriteLine("The product of {0} and {1} is: {2}", term1, term2, Product(ref term1, ref term2));
                //Print the Product operation and the result to screen

            //Stop program from terminating prematurely
            Console.ReadLine();
        }

        public static void Sum(ref int term1, ref int term2) //Accept the two terms by reference
        {
            Console.WriteLine("The sum of {0} and {1} is: {2}", term1, term2, (term1 + term2));
                //Print the Sum operation and result to screen
        }

        public static void Difference(ref int term1, ref int term2) //Accept the two terms by reference
        {
            Console.WriteLine("The difference of {0} and {1} is: {2}", term1, term2, (term1 - term2));
                //Print the Difference operation and the result to screen
        }

        public static Int64 Product(ref int term1, ref int term2) //Accept the two terms by reference
        {
            //Return the value of the two multiplied terms
            return ((Int64) term1*term2); //Cast a term to Int64 to handle exceptionally large values
        }
    }
}
