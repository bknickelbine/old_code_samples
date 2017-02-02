// Guess My Number v2.1 (modified by Tom Spengler)
// The new and improved number guessing game

#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int main()
{

    srand(time(0)); // seed random number generator

    int number;
    int cpuGuess;
    int countGuesses = 1; //Initialize countGuesses to 1 because computer has to make at least one guess

    cout << "\tWelcome to Guess My Number v2.0!\n\n";

    //Get number from user
    cout << "Enter a number 1-100 you want the computer to try and guess:" << endl;
    cin >> number;
    // input validation should be done here!

    // Version using a binary search instead of random guesses
    cpuGuess = 50;
    int first = 1;
    int last = 100;

    while (number != cpuGuess)
    {
        if (cpuGuess > number)
        {
            last = cpuGuess - 1;
            cout << "The computer guessed " << cpuGuess << " which was too high! Trying again..." << endl;
        }

        else
        {
            first = cpuGuess + 1;
            cout << "The computer guessed " << cpuGuess << " which was too low! Trying again..." << endl;
        }

        cpuGuess = (first + last)/2;      // calc next guess w/ binary chop
        countGuesses++;

    }

    //When the computer is finally right, print the original number and the number of tries it took the computer to find it
    cout << "The computer has found that your number was " << number << " in " << countGuesses << " guesses";

    //Spengler pause
    char dum;
    std::cin >> dum;

    return 0;
}
