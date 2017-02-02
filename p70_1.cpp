// Menu Chooser With Enumeration
// Demonstrates the switch statement and menu using enumeration

#include <iostream>
using namespace std;

int main()
{
    cout << "Difficulty Levels\n\n";
    cout << "1 - Easy\n";
    cout << "2 - Normal\n";
    cout << "3 - Hard\n\n";

    //Define enumeration with difficulty levels
    enum difficulty {easy = 1, normal, hard};

    int choice;
    cout << "Choice: ";
    cin >> choice;

    //Change switch statement cases to use enumeration values instead of simple integers
    switch (choice)
    {
    case easy:
        cout << "You picked Easy.\n";
        break;
    case normal:
        cout << "You picked Normal.\n";
        break;
    case hard:
        cout << "You picked Hard.\n";
        break;
    default:
        cout << "You made an illegal choice.\n";
    }

    //Spengler pause
    char dum;
    std::cin >> dum;

    return 0;


}
