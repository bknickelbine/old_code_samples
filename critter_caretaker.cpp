//Critter Caretaker 2.0
//Simulates caring for an improved virtual pet

#include <iostream>

using namespace std;

class Critter
{
public:
    Critter(int hunger = 0, int boredom = 0);
    void Talk();
    void Eat(int food = 4);
    void Play(int fun = 4);
    void printStats() const;

private:
    int m_Hunger;
    int m_Boredom;

    int GetMood() const;
    void PassTime(int time = 1);

};

Critter::Critter(int hunger, int boredom):
        m_Hunger(hunger),
        m_Boredom(boredom)
{}

inline int Critter::GetMood() const
{
    return (m_Hunger + m_Boredom);
}

void Critter::PassTime(int time)
{
    m_Hunger += time;
    m_Boredom += time;
}

void Critter::Talk()
{
    string x;
    string y;

    if (m_Hunger > 7)
        x = "starving";
    else if (m_Hunger > 5)
        x = "really hungry";
    else if (m_Hunger > 3)
        x = "hungry";
    else
        x = "full";

    if (m_Boredom > 7)
        y = "bored stiff!";
    else if (m_Boredom > 5)
        y = "really bored!";
    else if (m_Boredom > 3)
        y = "bored.";
    else
        y = "amused.";

    cout << "I'm a critter and I am " << x << " and I am also " << y;
    PassTime();
}

void Critter::Eat(int food)
{
    cout << "Brruppp.\n";
    m_Hunger -= food;
    if (m_Hunger < 0)
        m_Hunger = 0;
    PassTime();
}

void Critter::Play(int fun)
{
    cout << "Wheee!\n";
    m_Boredom -= fun;
    if (m_Boredom < 0)
        m_Boredom = 0;
    PassTime();
}

void Critter::printStats() const
{
    cout << "The critter's current stats are as follows:" << endl;
    cout << "Hunger: " << m_Hunger << endl;
    cout << "Boredom: " << m_Boredom << endl;
}

int main()
{
    Critter crit;

    int choice = 1;  //start the critter off talking
    while (choice != 0)
    {
        cout << "\nCritter Caretaker 2.0\n\n";
        cout << "0 - Quit\n";
        cout << "1 - Listen to your critter\n";
        cout << "2 - Feed your critter\n";
        cout << "3 - Play with your critter\n\n";

        cout << "Choice: ";
        cin >> choice;

        switch (choice)
        {
        case 0:
            cout << "Good-bye.\n";
            break;
        case 1:
            crit.Talk();
            break;
        case 2:
            crit.Eat();
            break;
        case 3:
            crit.Play();
            break;
        case 99: //Secret menu option
            crit.printStats();
            break;
        default:
            cout << "\nSorry, but " << choice << " isn't a valid choice.\n";
        }
    }

    return 0;
}

