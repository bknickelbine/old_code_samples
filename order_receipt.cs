using System; //Remove unused using directives inserted by Visual Studio

namespace OrderReceipt
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            //Declare string variables
            string name, address, city, state, zip;
            //Declare unsigned integer variable (user cannot order negative numbers of a product)
            uint quantity;
            //Declare double variables to hold the tax rate and price of the product
            double tax = 0.07, price = 39.95;

            //Prompt the user to enter their Name, Address, City, State, Zip Code, and how many products they wish to order
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Street address: ");
            address = Console.ReadLine();
            Console.Write("City: ");
            city = Console.ReadLine();
            Console.Write("State: ");
            state = Console.ReadLine();
            Console.Write("Zip code: ");
            zip = Console.ReadLine();
            Console.Write("How many Magic Blenders do you want to order? ");
            quantity = Convert.ToUInt32(Console.ReadLine()); //Cannot order a negative number here

            //Print the receipt to the console
            Console.WriteLine("\nRecipt for:");
            Console.WriteLine(name);
            Console.WriteLine(address);
            Console.WriteLine(city + ", " + state + " " + zip + "\n");

            //Print the quantity ordered, and the price per unit (in currency format)
            Console.WriteLine(quantity + " blender/s ordered @ " + price.ToString("C") + " each\n");

            //Print the subtotal to the console after formulating the value
            Console.WriteLine("Subtotal: " + (price*quantity).ToString("C")); //Calculate subtotal here instead of holding the value in a variable, saving memory at the cost of CPU.
            //Print the tax to the console after formulating the value
            Console.WriteLine("Tax: " + (price*quantity*tax).ToString("C")); //Calculate tax here instead of holding the value in a variable, saving memory at the cost of CPU.
            //Print a separator to the console
            Console.WriteLine("-----------------------------------------");
            //Print the final total to the console after formulating the value (subtotal + tax)
            Console.WriteLine("Total: " + ((price * quantity) + (price * quantity * tax)).ToString("C"));  //Calculate grand total here instead of holding the value in a variable, saving memory at the cost of CPU.

            //Prevent the application from terminating prematurely
            Console.Read();

        }
    }
}