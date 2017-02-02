// H05 Bonus
// Array Based Lottery Game 2.0

#include <iostream>
#include <cstdlib>
#include <ctime>
#include <algorithm>

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

        cout << endl << "Enter your next number (0-9, No duplicates please!): " << endl;
        cin >> a[i];
        i++;

    }

    cout << endl;

    return;

}

void lotteryPicks(int a[])
{
    //Declare array of values 0-9 to be shuffled
    int b[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    //Use the random_shuffle function to pick random, unique numbers
    random_shuffle(&b[0], &b[9]);

    //Assign the even numbered indexes (0-8) of shuffled array b to the lottery array
    for (int i = 0; i < 5; i++)
    {
        a[i] = b[i*2];
    }

    return;
}

void findMatches(int user[], int lottery[], int matched[])
{

    int i = 0;

    //Nested loop to find matching numbers
    while (i < 5)
    {
        for (int j = 0; j < 5; j++)
        {
            if (user[i] == lottery[j])
            {
                matched[i] = 1;
            }
        }

        i++;
    }

    return;

}

void printLottery(int a[])
{

    cout << "The lottery numbers (sorted) are: " << endl;

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

    //If total of the array is 0, the user has all incorrect answers
    if (a[0] + a[1] + a[2] + a[3] + a[4] == 0)
    {
        cout << "You didn't match any numbers!" << endl;
    }

}


int main()
{

    srand(time(0)); //Seed random number generator

    //Greet the user
    cout << "Welcome to the CIS204 Lottery 2.0! Pick your numbers and see if you're a winner!" << endl << endl;

    //Declare arrays for user picks, lottery numbers, and matched numbers between the two
    int user[5];
    int lottery[5];
    int matchedStacked[5] = {1,1,1,1,1}; //Cheat array to test jackpot scenario

    //Define loop sentinel
    char playAgain = 'y';

    while (playAgain == 'y')
    {

        //Re-initialize array to 0 for each run of the program
        int matched[5] = {0,0,0,0,0};

        //Get the user's numbers and generate lottery numbers
        userPicks(user);
        lotteryPicks(lottery);

        //Sort the lottery array
        int lotteryElements = sizeof(lottery) / sizeof(int);

        stable_sort(lottery, lottery + lotteryElements);

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
