using System; //Remove unused using directives inserted by Visual Studio

namespace Eggs
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Declare variables to hold the number of eggs for each of four chickens
            ushort chicken1, chicken2, chicken3, chicken4; //unsigned short integers don't allow for negative values

            //Prompt user to enter the number of eggs for each of four chickens, and store the values entered
            Console.Write("Please enter the number of eggs produced by Chicken #1: ");
            chicken1 = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Please enter the number of eggs produced by Chicken #2: ");
            chicken2 = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Please enter the number of eggs produced by Chicken #3: ");
            chicken3 = Convert.ToUInt16(Console.ReadLine());
            Console.Write("Please enter the number of eggs produced by Chicken #4: ");
            chicken4 = Convert.ToUInt16(Console.ReadLine());

            //Print the total number of eggs produced, after summing the eggs produced
            Console.Write("\nThe total number of eggs produced is: {0}", (chicken1 + chicken2 + chicken3 + chicken4));
            //Print the total in dozens (division) and remaining eggs (modulo).
            Console.Write("\nThis is equal to: {0} dozen, and {1} eggs left over.", (chicken1 + chicken2 + chicken3 + chicken4)/12, (chicken1 + chicken2 + chicken3 + chicken4)%12);

            Console.Read(); //Stop the program from teminating prematurely
        }
    }
}