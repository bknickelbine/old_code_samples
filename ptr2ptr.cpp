//Pointer to pointer bonus exercise

#include <iostream>

using namespace std;

int main()
{

    //Declare a string and initialize
    string str = "This is a string!";
    //Declare a pointer to a string and initialize
    string *ptrString = &str;
    //Declare a pointer to a pointer to string and initialize
    string **ptr2PtrString = &ptrString;

    //Display the result of calling size() on a pointer to a pointer
    cout << "The string '" << str << "' has " << (**ptr2PtrString).size() << " characters in it" << endl;

    return 0;

}
