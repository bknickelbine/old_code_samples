using System; //Remove unused using directives inserted by Visual Studio

namespace Calculate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Declare variables
            int operand1, operand2;
            char symbol;
            double result = 0; //Initialize the result to 0

            //Prompt the user to enter the numbers and operator, store them in their respective variables
            Console.Write("Enter the first number: ");
            operand1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter an operator (+,-,*,/): ");
            symbol = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter the second number: ");
            operand2 = Convert.ToInt32(Console.ReadLine());

            //Check for which operator was input
            switch (symbol)
            {
                case ('+'): //If addition
                    result = (operand1 + operand2);
                    break;
                case ('-'): //If subtraction
                    result = (operand1 - operand2);
                    break;
                case ('*'): //If multiplication
                    result = (operand1*operand2);
                    break;
                case ('/'): //If division
                    result = (double) operand1/operand2; //Cast operand to a double
                    break;
                default: //Otherwise it's an invalid symbol/operator
                    symbol = '\0'; //Set symbol to null
                    break;
            }

            if (symbol != '\0') //If it's a valid operator, print the result; If invalid, print error message
            {
                Console.WriteLine("\nThe result of {0} {1} {2} is: {3}", operand1, symbol, operand2, result);
            }
            else
            {
                Console.WriteLine("\nYou entered an invalid operator...");
            }

            Console.Read(); //Stop program from terminating prematurely
        }
    }
}