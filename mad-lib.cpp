// Mad-Lib 3.0
// Creates a story based on user input, using pointers!

#include <iostream>
#include <string>

using namespace std;

//Change function parameters to be constant pointers to constant values (No values need to be changed, only used)
string askText(const string * const prompt);
int askNumber(const string * const prompt);
void tellStory(const string * const name, const string * const noun, int number, const string * const bodyPart, const string * const verb);

int main()
{
    cout << "Welcome to Mad Lib 3.0!\n\n";
    cout << "Answer the following questions to help create a new story.\n";

    string prompt[] = {"Please enter a name: ", "Please enter a plural noun: ", "Please enter a number: ",
    "Please enter a body part: ", "Please enter a verb: "};

    string name = askText(&prompt[0]);
    string noun = askText(&prompt[1]);
    int number = askNumber(&prompt[2]);
    string bodyPart = askText(&prompt[3]);
    string verb = askText(&prompt[4]);

    tellStory(&name, &noun, number, &bodyPart, &verb);

    return 0;
}

string askText(const string * const prompt)
{
    string text;
    cout << *prompt;
    cin >> text;
    return text;
}

int askNumber(const string * const prompt)
{
    int num;
    cout << *prompt;
    cin >> num;
    return num;
}

void tellStory(const string * const name, const string * const noun, int number, const string * const bodyPart, const string * const verb)
{
    cout << "\nHere's your story:\n";
    cout << "The famous explorer ";
    cout << *name;
    cout << " had nearly given up a life-long quest to find\n";
    cout << "The Lost City of ";
    cout << *noun;
    cout << " when one day, the ";
    cout << *noun;
    cout << " found the explorer.\n";
    cout << "Surrounded by ";
    cout << number;
    cout << " " << *noun;
    cout << ", a tear came to ";
    cout << *name << "'s ";
    cout << *bodyPart << ".\n";
    cout << "After all this time, the quest was finally over. ";
    cout << "And then, the ";
    cout << *noun << "\n";
    cout << "promptly devoured ";
    cout << *name << ". ";
    cout << "The moral of the story? Be careful what you ";
    cout << *verb;
    cout << " for.";
}

