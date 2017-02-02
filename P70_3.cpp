// Guess My Number v2.0
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

    //Generate random CPU guess from 1-100
    cpuGuess = rand() % 100 + 1;

    //When the computer isn't right, print either high or low and generate new random number
    while (number != cpuGuess)
    {


        if (cpuGuess > number)
        {
            cout << "The computer guessed " << cpuGuess << " which was too high! Trying again..." << endl;
        }

        else
        {
            cout << "The computer guessed " << cpuGuess << " which was too low! Trying again..." << endl;
        }

        cpuGuess = rand() % 100 + 1;
        countGuesses++;

    }

    //When the computer is finally right, print the original number and the number of tries it took the computer to find it
    cout << "The computer has found that your number was " << number << " in " << countGuesses << " guesses";

    //Spengler pause
    char dum;
    std::cin >> dum;

    return 0;
}
