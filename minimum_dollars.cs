using System; //Remove unused using directives inserted by Visual Studio

namespace Dollars
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Prompt the user to enter a monetary value in dollars
            Console.WriteLine("Please enter an amount of money in dollars: ");

            //Store the amount in the money integer variable
            int money = Math.Abs(Convert.ToInt32(Console.ReadLine())); //Absolute value used to handle negative values

            //Create array with acceptable denominations
            int[] denoms = {20, 10, 5, 1};

            //Print new line
            Console.WriteLine();

            //Call the ConvertMoney method and pass the monetary value by reference,
            //the array of denominations, and the starting iteration number (0)
            ConvertMoney(ref money, denoms, 0);

            //Stop the program from terminating prematurely
            Console.ReadLine();
        }

        //ConvertMoney to find the fewest number of bills
        public static void ConvertMoney(ref int moneyLeft, int[] denom, int iteration)
        {
            //If the current iteration is out of bounds
            if (iteration > denom.Length)
            {
                return; //Return from the function and do not continue
            }

            //If the money remaining is divisible by the denomination, you are done here
            if (moneyLeft%denom[iteration] == 0)
            {
                //Print the number of bills of the current denomination needed to reach the total
                Console.WriteLine("{0}s: {1}", denom[iteration], moneyLeft/denom[iteration]);
            }

                //Otherwise..
            else
            {
                //Print the number of bills in that denomination that can be used toward reaching the total
                Console.WriteLine("{0}s: {1}", denom[iteration], moneyLeft/denom[iteration]);

                //Subtract that amount from the remaining money
                moneyLeft = moneyLeft - (moneyLeft/denom[iteration]*denom[iteration]);

                //Recursive call to ConvertMoney to handle the remaining denominations
                ConvertMoney(ref moneyLeft, denom, ++iteration);
            }
        }
    }
}
