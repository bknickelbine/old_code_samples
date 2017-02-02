// H04_1: Favorite Game List Maintainer using Vectors and Iterators

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{

    //Declare Vector and Iterator
    vector<string> favoriteGames;
    vector<string>::const_iterator iter;

    //Greet the user
    cout << "Welcome to the favorite game maintainer!" << endl << endl;

    //Loop the menu choice until the user quits from inside the loop
    while (true)
    {

        int menuChoice;

        //Display the menu options
        cout << "1. Add game to the favorites list" << endl;
        cout << "2. Remove game from the favorites list" << endl;
        cout << "3. List games in the favorites list" << endl;
        cout << "4. Quit" << endl;

        //Get the option choice from the user
        cin >> menuChoice;

        cout << endl;

        switch (menuChoice)
        {
        case 1:
        {

            //Declare the string variable that will hold the name of one of the user's favorite games
            string gameName;

            //Get the user's favorite game (without spaces) and add it to the vector
            cout << "Enter the name of the game you would like to add to the list of favorites (No spaces allowed): " << endl;
            cin >> gameName;
            favoriteGames.insert(favoriteGames.begin(), gameName);
            cout << endl;
        }

        break;

        case 2:
        {

            int gameNum;
            int currentNum = 1;

            //List the games available to delete
            cout << "List of favorite games:" << endl << endl;

            for (iter = favoriteGames.begin(); iter != favoriteGames.end(); ++iter)
            {
                cout << currentNum << ": " << *iter << endl;
                currentNum++;
            }

            cout << endl;

            //Allow user to select which game they want to erase from the list
            cout << "Enter the number of the game you would like to remove from the list of favorites:" << endl;
            cin >> gameNum;
            favoriteGames.erase(favoriteGames.begin() + (gameNum - 1));
            cout << endl;
        }

        break;

        case 3:
        {

            //List all the games contained in the vector
            cout << "List of favorite games:" << endl << endl;

            for (iter = favoriteGames.begin(); iter != favoriteGames.end(); ++iter)
            {
                cout << *iter << endl;
            }

            cout << endl;

        }

        break;

        case 4:
        {

            //Quit the program
            return 0;
        }

        break;

        default:
        {
            //Tell the user their choice is invalid
            cout << "Invalid choice!" << endl << endl;
        }
        break;

        cout << endl << endl;


        }

    }

    return 0;

}
