#include <iostream>

using namespace std;

int main()
{

// Declare variables

    float firstScore, secondScore, thirdScore;

//Get the user's scores

    cout << "Please enter three numerical scores to be averaged" << endl << endl;

    cout << "First score:" << endl;
    cin >> firstScore;

    cout << "Second score:" << endl;
    cin >> secondScore;

    cout << "Third score:" << endl;
    cin >> thirdScore;

//Calculate result and print it back to the user

    cout << "The average of the three scores is:" << endl;

    cout << (firstScore + secondScore + thirdScore) / 3 << endl;

    return 0;

}
