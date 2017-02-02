// H04 Bonus
// Array Based Lottery Game

#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

void userPicks(int a[])
{

    int i = 0;

    //Ask the user for their first number
    cout << "Enter your first number (0-9): " << endl;
    cin >> a[i];
    i++;

    //Ask the user for their subsequent numbers
    while (i < 5)
    {


        cout << endl << "Enter your next number (0-9): " << endl;
        cin >> a[i];
        i++;

    }

    cout << endl;

    return;

}

void lotteryPicks(int a[])
{

    int i = 0;

    while (i < 5)
    {

        //Generate a number 0-9 and assign it to the current index
        a[i] = rand() % 10;
        i++;

    }

    return;

}

void findMatches(int user[], int lottery[], int matched[])
{

    int i = 0;

    //Iterate through the array
    while (i < 5)
    {

        //If the two indexes are a match, set matched[i] to be 1. This signifies a correct match.
        if (lottery[i] == user[i])
        {
            matched[i] = 1;
        }

        //Otherwise, set matched[i] to be 0. This signifies an incorrect guess.
        else
        {

            matched[i] = 0;

        }

        i++;

    }

    return;

}

void printLottery(int a[])
{

    cout << "The lottery numbers are: " << endl;


    //Print all the lottery numbers
    for (int i = 0; i < 5; i++)
    {

        cout << a[i] << "\t";

    }

    return;

}

void printUser(int a[])
{


    cout << endl << "Your numbers are: " << endl;

    //Print all the user's picks
    for (int i = 0; i < 5; i++)
    {

        cout << a[i] << "\t";

    }

    cout << endl;

    return;

}

void printMatched(int a[])
{

    cout << "You had matches with lottery number/s: ";

    //Print the number positions that match in both the user and lottery arrays
    for (int i = 0; i < 5; i++)
    {
        if (a[i] == 1)
        {
            cout << i + 1 << " ";
        }

    }

    //If total of the array is 5, the user has all correct answers and wins the jackpot
    if (a[0] + a[1] + a[2] + a[3] + a[4] == 5)
    {

        cout << "You hit the JACKPOT!" << endl;

    }

}


int main()
{

    srand(time(0)); //Seed random number generator

    //Greet the user
    cout << "Welcome to the CIS204 Lottery! Pick your numbers and see if you're a winner!" << endl << endl;

    //Declare arrays for user picks, lottery numbers, and matched numbers between the two
    int user[5];
    int lottery[5];
    int matched[5];
    int matchedStacked[5] = {1,1,1,1,1}; //Cheat array to test jackpot scenario

    //Define loop sentinel
    char playAgain = 'y';

    while (playAgain == 'y')
    {

        //Get the user's numbers and generate lottery numbers
        userPicks(user);
        lotteryPicks(lottery);

        //Find matches between the user numbers and the lottery numbers, using the matched array to keep track
        findMatches(user, lottery, matched);

        //Print all items contained in the lottery array
        printLottery(lottery);

        //Print all items contained in the user array
        printUser(user);

        //Print out which numbers the user matched with the lottery, and if they matched all numbers tell them they've won the jackpot
        //Use cheat array (matchStacked) to test jackpot scenario without having to get it through normal means
        printMatched(matched);

        //Ask the user if they want to try their luck again. If not, quit the program.
        cout << endl << endl << "Enter y to play again, or anything else to quit" << endl;
        cin >> playAgain;
        cout << endl << endl;
    }

    return 0;
}
