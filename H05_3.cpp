#include <iostream>
#include <string>

using namespace std;

int askGetNumber(string prompt = "Please input a number: ")
{

    int number;

    cout << prompt << endl;
    cin >> number;
    return number;

}

int askGetNumberOverload()
{
    int number;

    cout << "Please input a number: " << endl;
    cin >> number;
    return number;
}

int askGetNumberOverload(string prompt)
{
    int number;

    cout << prompt << endl;
    cin >> number;
    return number;
}

void spenglerPause()
{
    //Spengler pause
    char dum;
    std::cin >> dum;
}

int main()
{

    //Function call with no arguments to demonstrate default arguments
    askGetNumber();

    //Function call with a prompt argument
    askGetNumber("Please enter a number: ");

    //Function call with no arguments
    askGetNumberOverload();

    //Function call with a prompt argument to demonstrate function overloading
    askGetNumberOverload("Please enter a number: ");

    spenglerPause();

}
