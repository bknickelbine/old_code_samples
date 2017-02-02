using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WH33LofF0RTUN3
{
    internal class Program
    {

        /**********************************************************************
        *
        * Created by Benjamin Knickelbine
        *
        * ********************************************************************/
        public class Puzzle
        {
            public string Subject { get; set; } //Subject of the puzzle
            public string Statement //Statement in the puzzle (what the contestants try and solve)
            {
                get { return Statement; }
                set { ConvertToLetters(value); }
            }
            public List<Letter> puzzleLetters = new List<Letter>();//List of letter objects in the puzzle

            public void ConvertToLetters(string s)//Convert the string into a list of letters
            {
                for (int i = 0; i < s.Length; ++i)
                {
                    puzzleLetters.Add(new Letter());
                    puzzleLetters[i].PuzLetter = Convert.ToChar(s[i]);
                }
            }
        }
        /**********************************************************************
        *
        * Created by Benjamin Knickelbine
        *
        * ********************************************************************/
        public class Letter
        {
            private char puzletter; //Private puzzle letter variable
            private bool isVisible = false; //Default visibilty set to false

            public char PuzLetter//Public puzzle letter variable
            {
                get { return puzletter; }
                set { puzletter = value; }
            }
            public bool IsVisible//Public visibilty variable
            {
                get { return isVisible; }
                set { isVisible = value; }
            }
        }
        /**********************************************************************
        *
        * Created by Rodney Lockhart with bools by Benjamin Knickelbine
        *
        * ********************************************************************/
        public static class Global //Global variable definition
        {
            public static bool isPuzzleSolved; //Is the puzzle solved yet?
            public static byte player; //Number of the player in the array
            public static bool[] GuessedLetters = new bool[26]; //Guessed letters in the puzzle
            public static byte CCount { get; set; } //Count of the number of contestants
            public static int Position { get; set; } //Position of the wheel
            public static byte VCount; //Count of the vowels left
            public static byte finalist; //Number of the finalist who made it to the final round

        }

        /**********************************************************************
        *
        * Created by Rodney Lockhart
        *
        * ********************************************************************/
        public class Contestant //Public Class Contestant
        {
            public int winnings { get; set; } //running tab of winnings per round
            public string Name { get; set; } //Name of the contestant
            public int RoundWinnings { get; set; } //Amount won in all rounds
            public int RoundsWon { get; set; } //Number of rounds won
            public string special { get; set; } //String to hold special prize

        }
        /**********************************************************************
        *
        * Created by Benjamin Knickelbine and Rodney Lockhart and VS
        *
        * ********************************************************************/
        private static void Main(string[] args)
        {   //Set the window size (unstable)
            Console.SetWindowSize(Console.LargestWindowWidth - 100, Console.LargestWindowHeight - 30);

            char playAgain = 'Y';
            do
            {
                SplashScreen();//Print the splash screen to the screen Method call

                Console.ForegroundColor = ConsoleColor.White;//letter coloring on display
                Console.BackgroundColor = ConsoleColor.Black;//screen color
                Console.Clear();//Clears the screen
                System.Threading.Thread.Sleep(500); //Pause the game for .5 seconds
                Console.WriteLine("How many players will be playing? (1-3)");//Prompt to get the number of players
                byte numPlayers;

                /* Error trapping */

                try
                {
                    numPlayers = Convert.ToByte(Console.ReadLine());//user input
                }

                catch (Exception)
                {
                    numPlayers = 255;//Set to known bad value

                }

                while (numPlayers > 3)
                {
                    Console.WriteLine("That is not a valid number of players!");//user prompt output
                    Console.WriteLine("How many players will be playing? (1-3)");//user prompt output
                    try
                    {
                        numPlayers = Convert.ToByte(Console.ReadLine());//user input
                    }

                    catch (Exception)
                    {
                        numPlayers = 255;//Set to known bad value

                    }
                }
                Contestant[] contestant = new Contestant[numPlayers];//Create new array of contestants
                Console.Clear();//Clears the screen
                Console.WriteLine("Let's meet our contestants");//user prompt output
                System.Threading.Thread.Sleep(2000);//Pause the screen for 2 seconds
                MeetContestants(contestant);//Meet the contestant Method Call
                Rounds(contestant);//Play rounds Method Call

                Console.WriteLine("Would you like to play again?");//user prompt output
                Console.WriteLine("Y or N");
                try
                {
                    playAgain = Convert.ToChar(Console.ReadLine());//user input
                    playAgain = char.ToUpper(playAgain);
                }
                catch(Exception)
                {

                    playAgain = 'N';

                }
                Char.ToUpper(playAgain);
                Console.Clear();
            } while (playAgain == 'Y');
        }
        /**********************************************************************
        *
        *  Splash screen function opening Logo
        *  Created by Rodney Lockhart
        *
        * ********************************************************************/

        public static void SplashScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Output color
            Console.WriteLine("\n");
            Console.WriteLine("XX        XX  XX    XX  XXXXXXXX  XXXXXXX   XX");
            Console.WriteLine("XX        XX  XX    XX  XX        XX        XX");
            Console.WriteLine("XX        XX  XX    XX  XX        XX        XX");
            Console.WriteLine("XX   XX   XX  XXXXXXXX  XXXXX     XXXXX     XX");
            Console.WriteLine("XX  XXXX  XX  XX    XX  XX        XX        XX");
            Console.WriteLine(" XXXX  XXXX   XX    XX  XX        XX        XX");
            Console.WriteLine("  XX    XX    XX    XX  XXXXXXXX  XXXXXXXX  XXXXXXXX");
            System.Threading.Thread.Sleep(1500); //Pause the game for 1.5 seconds
            Console.ForegroundColor = ConsoleColor.Red;//Output color
            Console.WriteLine("\n\n");
            Console.WriteLine(" XXXXXX   XXXXXXXX");
            Console.WriteLine("XX    XX  XX");
            Console.WriteLine("XX    XX  XX");
            Console.WriteLine("XX    XX  XXXXXX");
            Console.WriteLine("XX    XX  XX");
            Console.WriteLine("XX    XX  XX");
            Console.WriteLine(" XXXXXX   XX");
            System.Threading.Thread.Sleep(1500); //Pause the game for 1.5 seconds
            Console.ForegroundColor = ConsoleColor.Green;//Output color
            Console.WriteLine("\n\n");
            Console.WriteLine("XXXXXXXX  XXXXXX   XXXXXXX  XXXXXXXX  XX    XX  XX    XX  XXXXXXXX");
            Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XXX   XX  XX");
            Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XXXX  XX  XX");
            Console.WriteLine("XXXXXX   XX    XX  XXXXXXX     XX     XX    XX  XX XX XX  XXXXXX");
            Console.WriteLine("XX       XX    XX  XX   XX     XX     XX    XX  XX  XXXX  XX");
            Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XX   XXX  XX");
            Console.WriteLine("XX        XXXXXX   XX     XX   XX      XXXXXX   XX    XX  XXXXXXXX");
            System.Threading.Thread.Sleep(500);

            /**********************************************************************
            *
            * Animation inspired by Tiffany
            *   Created by Benjamin Knickelbine
            *
            * ********************************************************************/

            for (byte x = 0; x < 3; ++x)
            {
                Console.Clear();//Clears the screen

                Type type = typeof(ConsoleColor);//Output color
                foreach (var name in Enum.GetNames(type))
                {
                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);//Output color

                    Console.Clear();//Clears the screen

                    Console.WriteLine("\n\n");
                    Console.WriteLine("XX        XX  XX    XX  XXXXXXXX  XXXXXXX   XX");
                    Console.WriteLine("XX        XX  XX    XX  XX        XX        XX");
                    Console.WriteLine("XX        XX  XX    XX  XX        XX        XX");
                    Console.WriteLine("XX   XX   XX  XXXXXXXX  XXXXX     XXXXX     XX");
                    Console.WriteLine("XX  XXXX  XX  XX    XX  XX        XX        XX");
                    Console.WriteLine(" XXXX  XXXX   XX    XX  XX        XX        XX");
                    Console.WriteLine("  XX    XX    XX    XX  XXXXXXXX  XXXXXXXX  XXXXXXXX");
                    Console.WriteLine("\n\n");
                    Console.WriteLine(" XXXXXX   XXXXXXXX");
                    Console.WriteLine("XX    XX  XX");
                    Console.WriteLine("XX    XX  XX");
                    Console.WriteLine("XX    XX  XXXXXX");
                    Console.WriteLine("XX    XX  XX");
                    Console.WriteLine("XX    XX  XX");
                    Console.WriteLine(" XXXXXX   XX");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("XXXXXXXX  XXXXXX   XXXXXXX  XXXXXXXX  XX    XX  XX    XX  XXXXXXXX");
                    Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XXX   XX  XX");
                    Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XXXX  XX  XX");
                    Console.WriteLine("XXXXXX   XX    XX  XXXXXXX     XX     XX    XX  XX XX XX  XXXXXX");
                    Console.WriteLine("XX       XX    XX  XX   XX     XX     XX    XX  XX  XXXX  XX");
                    Console.WriteLine("XX       XX    XX  XX    XX    XX     XX    XX  XX   XXX  XX");
                    Console.WriteLine("XX        XXXXXX   XX     XX   XX      XXXXXX   XX    XX  XXXXXXXX");

                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        /**********************************************************************
        *
        *  Function to play all the rounds in a game (including final)
        * Created by Benjamin Knickelbine and Rodney Lockhart
        * ********************************************************************/
        public static void Rounds(Contestant[] contestant)
        {
            List<Puzzle> puzzles = new List<Puzzle>(); //create/assign & initialize List
            LoadPuzzles(puzzles); //Read puzzles from puzzles file

            byte rounds = 1;
            byte x;

            for (x = 0; x < rounds; ++x)
            {
                byte y = x;
                Console.Clear(); //Clear the screen
                Console.ForegroundColor = ConsoleColor.Yellow; //letter coloring on display
                Console.WriteLine("Welcome to round: " + (y + 1)); //alternate contestant variable for display
                System.Threading.Thread.Sleep(3000); //Pause the game for 3 seconds
                Puzzle currentPuzzle = SelectPuzzle(puzzles);//create/assign & initialize array
                Global.VCount = 5; //Vowels
                fillGuessed();//Call to method that fills an array with letters that have been guessed
                Console.Clear(); //Clear the screen
                Console.ForegroundColor = ConsoleColor.Green;//letter coloring on display
                Console.WriteLine("Let's get ready for the puzzle!");
                System.Threading.Thread.Sleep(3000); //Pause the game for 3 seconds
                Console.Clear();//Clears the screen
                Console.ForegroundColor = ConsoleColor.Cyan;//letter coloring on display
                Console.WriteLine("The category for the puzzle is: {0}", currentPuzzle.Subject);
                revealPunct(currentPuzzle.puzzleLetters);
                printPuzzle(currentPuzzle); //Print the current puzzle
                Console.WriteLine("\n");
                Global.isPuzzleSolved = false;
                CallContestant(contestant, currentPuzzle, y);
            }

            if (Global.CCount > 1)
                tabulateScoresRounds(contestant);


            FinalRound(contestant);

            Console.WriteLine("\nGAME OVER");
            System.Threading.Thread.Sleep(3000);

        }
        /**********************************************************************
        *
        *  Final round function to play a final round
        *   Rodney Lockhart
        *********************************************************************/

        public static void FinalRound(Contestant[] contestant)
        {
            byte x;

            if(Global.CCount > 1)
                x = Global.finalist;
            else
                x = 0;

            byte z = 0;
            List<Puzzle> puzzles = new List<Puzzle>();
            LoadPuzzles(puzzles); //Read puzzles from puzzles file
            Puzzle currentPuzzle = SelectPuzzle(puzzles);
            List<Letter> statement = currentPuzzle.puzzleLetters;
            Console.WriteLine("The category for the puzzle is: {0}", currentPuzzle.Subject);
            revealPunct(currentPuzzle.puzzleLetters);

            Global.isPuzzleSolved = false;

            // RSTLNE Benjamin Knickelbine
            Console.WriteLine("Reveal R, S, T, L, N and E");
            revealLetters(statement, 'R', currentPuzzle);
            Console.Clear();
            revealLetters(statement, 'S', currentPuzzle);
            Console.Clear();
            revealLetters(statement, 'T', currentPuzzle);
            Console.Clear();
            revealLetters(statement, 'L', currentPuzzle);
            Console.Clear();
            revealLetters(statement, 'N', currentPuzzle);
            Console.Clear();
            revealLetters(statement, 'E', currentPuzzle);
            Console.Clear();

            Console.WriteLine("Welcome to the Bonus Round");
            Console.WriteLine("You will be given one spin");

            spinWheel(statement, currentPuzzle, contestant, x, z);

            byte y = 99;

            for (byte iv = 3; iv != 0 && Global.isPuzzleSolved == false; iv--)
                {
                    Console.WriteLine("You have {0} guesses.", iv);
                    solvePuzzle(statement, y, currentPuzzle, contestant, x);

                }
            }


        /**********************************************************************
        *
        *  Function to call each contestant and give them their information,
        *  and menu choices until the puzzle is solved
        *   Benjamin Knickelbine and Rodney Lockhart
        *********************************************************************/

        public static void CallContestant(Contestant[] contestant, Puzzle puzzle, byte y)
        {
            byte x = 0;
            while (Global.isPuzzleSolved == false)
            {
                for (x = 0; x < Global.CCount && Global.isPuzzleSolved == false; ++x)
                {
                    byte z = 200;
                    Console.ForegroundColor = ConsoleColor.White;//letter coloring on display

                    Console.WriteLine("\n" + contestant[x].Name + "'s Turn");//user prompt output
                    /*Console.WriteLine("Global Bank $" + contestant[x].RoundWinnings);//used for testing
                    Console.WriteLine("Rounds Won " + contestant[x].RoundsWon);*/
                    //used for testing

                    Console.WriteLine("Bank $" + contestant[x].winnings + ".00");//output

                    if (contestant[x].winnings >= 250)
                    {
                        switch (contestantMenu(1))
                        {
                            case 1:
                                spinWheel(puzzle.puzzleLetters, puzzle, contestant, x, z);
                                break;
                            case 2:
                                BuyAvowel(puzzle.puzzleLetters, contestant[x], puzzle, z);
                                break;
                            case 3:
                                solvePuzzle(puzzle.puzzleLetters, y, puzzle, contestant, x);
                                break;
                            default:
                                Console.WriteLine("Invalid selection!");
                                break;
                        }
                    }

                    else if (contestant[x].winnings < 250 || Global.VCount < 1)
                    {
                        switch (contestantMenu(2))
                        {
                            case 1:
                                spinWheel(puzzle.puzzleLetters, puzzle, contestant, x, z);
                                break;
                            case 2:
                                solvePuzzle(puzzle.puzzleLetters, y, puzzle, contestant, x);
                                break;
                            default:
                                Console.WriteLine("Invalid selection!");
                                break;
                        }
                    }
                    if (Global.isPuzzleSolved == false && Global.player > 0)
                    {
                        --x;
                    }
                }
            }
        }

        /**********************************************************************
        *
        *  Function to print the contestant menu and return their choice
        *    Benjamin Knickelbine
        * ********************************************************************/


        public static byte contestantMenu(int menuType)
        {
            string userChoice;

            switch (menuType)
            {

                case 1:
                    Console.WriteLine("\n\nWhat would you like to do?");//user prompt output
                    Console.WriteLine("1. Spin the wheel");//user prompt output
                    Console.WriteLine("2. Buy a vowel");//user prompt output
                    Console.WriteLine("3. Solve the puzzle");//user prompt output
                    userChoice = Console.ReadLine();//user input


                    try
                    {
                        return Convert.ToByte(userChoice);
                    }
                    catch (Exception)
                    {
                        return 99;
                    }
                case 2:
                    Console.WriteLine("\n\nWhat would you like to do?");//user prompt output
                    Console.WriteLine("1. Spin the wheel");//user prompt output
                    Console.WriteLine("2. Solve the puzzle");//user prompt output
                    userChoice = Console.ReadLine();//user input
                    try
                    {
                        return Convert.ToByte(userChoice);
                    }
                    catch (Exception)
                    {
                        return 99;
                    }
            }
            return Convert.ToByte(99);
        }

        /**********************************************************************
        *
        *  Function to load all puzzles from the C:\Puzzles.txt file
        *   Benjamin Knickelbine
        * ********************************************************************/


        public static void LoadPuzzles(List<Puzzle> puzzleList)
        {
            //Open the puzzles file from the hard drive
            try
            {
                FileStream fileStream = new FileStream(@"c:\puzzles.txt", FileMode.Open);
                try //Try to..
                {
                    using (StreamReader reader = new StreamReader(fileStream)) //Open a new stream reader
                    {
                        for (int i = 0; reader.EndOfStream != true; i++) //Until the end of the file
                        {
                            puzzleList.Add(new Puzzle()); //Create a new contact
                            puzzleList[i].Subject = reader.ReadLine(); //Read in a subject to the puzzle object
                            puzzleList[i].Statement = reader.ReadLine();//reader in puzzle statement to the puzzle object
                            //Read in a statement (what the player solves) to the puzzle object
                        }
                        reader.Close(); //Close the stream reader
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(
                        "C:\\puzzles.txt could not be read. Program will now terminate.\nPress any key to continue...");
                    Console.ReadKey();
                    fileStream.Close(); //Close the file stream
                    Environment.Exit(0); //Close the program
                }
                finally //Finally..
                {
                    fileStream.Close(); //Close the file stream
                }
            }
            catch (Exception)
            {
                Console.WriteLine(
                    "C:\\puzzles.txt could not be read. Program will now terminate.\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /**********************************************************************
        *
        * Function to select a puzzle from the list of puzzles
        *    Benjamin Knickelbine
        * ********************************************************************/


        private static Puzzle SelectPuzzle(List<Puzzle> puzzleList)
        {
            var randy = new Random();
            //Return a random puzzle object from the list of puzzles
            return puzzleList[randy.Next(0, puzzleList.Count)];
        }

        public static void revealPunct(List<Letter> puzzle)
        {
            byte numRevealed = 0;
            foreach (Letter l in puzzle)
            {
                //If the letter is a punctuation mark or space, it is given free to the player
                if (char.IsPunctuation(l.PuzLetter))
                {
                    //Set the character to be visible
                    l.IsVisible = true;
                    ++numRevealed; //Increment the counter
                }
            }
        }

        /**********************************************************************
        *
        * Function to meet the contestants and find out their name/s
        *   Rodney Lockhart
        * ********************************************************************/


        private static void MeetContestants(Contestant[] contestant)
        {
            while (Global.CCount < contestant.Length)
            {

                contestant[Global.CCount] = new Contestant();
                Console.Clear();//Clears the screen
                Console.Write("Please enter your name contestant #{0}? ", (Global.CCount + 1));
                contestant[Global.CCount].Name = Console.ReadLine();//user input
                Global.CCount++;
            }
        }//Terminator
        /**********************************************************************
         *
         * Function for a contestant to buy a vowel
         *       Benjamin Knickelbine
         * ********************************************************************/

        private static void BuyAvowel(List<Letter> puzzle, Contestant contestant, Puzzle currentPuzzle, byte y)
        {
            char input;
            Console.WriteLine("Select a vowel (a, e, i, o, u):");
            try
            {
                input = Convert.ToChar(Console.ReadLine());//user input
            }
            catch (Exception)
            {
                input = '\0';
            }
            while (input == '\0' || !char.IsLetter(input))
            {
                Console.WriteLine("That is not a vowel! Please select a vowel (a, e, i, o, u):");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());//user input
                }
                catch (Exception)
                {
                    input = '\0';
                }
            }
            while (input != 'a' && input != 'e' && input != 'i' && input != 'o' && input != 'u')
            {
                Console.WriteLine("That is not a vowel! Please select a vowel (a, e, i, o, u):");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());//user input
                }
                catch (Exception)
                {
                    input = '\0';
                }
            }
            if (isGuessed(input))
            {
                Global.player = 0;
                Console.WriteLine("The letter {0} has already been guessed!", char.ToUpper(input));
                return;
            }
            revealLetters(puzzle, input, currentPuzzle);
            if (y != 99)
            {
                contestant.winnings -= 250;
            }
            --Global.VCount;
            if (Global.VCount < 1)
            {
                Console.WriteLine("\nThere are no more vowels in the puzzle!");
            }



        }//Terminator

        /**********************************************************************
        *
        * Function to 'spin' a wheel of values
        *    Benjamin Knickelbine and Rodney Lockhart
        * ********************************************************************/


        public static void spinWheel(List<Letter> puzzle, Puzzle currentPuzzle, Contestant[] contestant, byte cnum, byte z)
        {
            string[] wheelValues;

            string[] a = {
                            "600", "400", "300", "Lose a turn", "800", "350", "450", "700",
                            "300", "600", "5000", "600", "500", "300", "500", "800",
                            "550", "400", "300", "900", "500", "300", "900", "BANKRUPT"
                            };

            string[] b = {
                            "40000", "20000", "10000", "SPORTS CAR", "60000", "15000", "25000", "50000",
                            "10000", "40000", "100000", "40000", "30000", "10000", "30000", "60000",
                            "35000", "20000", "10000", "75000", "30000", "10000", "900", "TRIP TO HAWAII"
                            };

            if (z == 0)
                wheelValues = b;
            else
                wheelValues = a;

            byte selection;
            int Spin;
            Console.WriteLine("\nPlease select:\t1. Soft");
            Console.WriteLine("\t\t2. Medium");
            Console.WriteLine("\t\t3. Hard");

            try
            {
                selection = Convert.ToByte(Console.ReadLine());//user input
            }
            catch (Exception)
            {
                selection = 255;//Set to known bad value

            }
            while (selection != 1 && selection != 2 && selection != 3)
            {
                Console.WriteLine("That is not a valid entry!");
                Console.WriteLine("\n Please select:\t1. Soft");
                Console.WriteLine("\t\t2. Medium");
                Console.WriteLine("\t\t3. Hard");

                try
                {
                    selection = Convert.ToByte(Console.ReadLine());//user input
                }
                catch (Exception)
                {
                    selection = 255;//Set to known bad value

                }
            }
            byte startPosition = (byte)Global.Position;
            int rotations = 0;
            int slots = 0;
            Random pick = new Random();
            switch (selection)
            {
                case 1: //Slow
                    Spin = (pick.Next(1, 24));
                    rotations = Spin / 24; //only needed for visuals if incorporated
                    slots = Spin % 24;
                    Global.Position = Global.Position + slots; //move pointer to new location
                    if (Global.Position > 23)
                        Global.Position = Global.Position - 24; //takes us to potentially array instance 0
                    break; //no fall through
                case 2: //Medium
                    Spin = (pick.Next(24, 72));
                    rotations = Spin / 24; //only needed for visuals if incorporated
                    slots = Spin % 24;
                    Global.Position = Global.Position + slots; //move pointer to new location
                    if (Global.Position > 23)
                        Global.Position = Global.Position - 24; //takes us to potentially array instance 0
                    break;
                case 3: //Fast
                    Spin = (pick.Next(72, 96));
                    rotations = Spin / 24; //only needed for visuals if incorporated
                    slots = Spin % 24;
                    Global.Position = Global.Position + slots; //move pointer to new location
                    if (Global.Position > 23)
                        Global.Position = Global.Position - 24; //takes us to potentially array instance 0
                    break;
            } //"Switch" Block Terminator

            animateWheel(wheelValues, startPosition, (byte)rotations, (byte)Global.Position);
            Console.ForegroundColor = ConsoleColor.Cyan;//letter coloring on display
            Console.WriteLine("The category for the puzzle is: {0}", currentPuzzle.Subject);
            printPuzzle(currentPuzzle);
            Console.ForegroundColor = ConsoleColor.White;//letter coloring on display

            //used for testing
            /*Console.WriteLine("\n\nThe wheel position is " + Global.Position);
            Console.WriteLine("The wheel spun around " + rotations + " Time(s)");
            Console.WriteLine("and moved " + slots + " more slots\n");*/
            /**********************************************************************
            *
            * Final Round modifications by Rodney Lockhart
            *
            * ********************************************************************/
            if (z == 0)
            {
                byte x = Global.finalist;
                byte y = 99;
                switch (Global.Position)
                {
                    case 3: //Player landed on Lose a turn
                        //Global.player = 0;
                        Console.WriteLine(wheelValues[Global.Position]);
                        for (byte f = 0; f < 3; ++f)
                        {
                            PickALetter(puzzle, wheelValues, currentPuzzle, contestant, cnum, z);
                        }
                        contestant[x].special = wheelValues[Global.Position];
                        BuyAvowel(puzzle, contestant[x], currentPuzzle, y);


                        break;
                    case 23: //Player landed on BANKRUPT
                        Console.WriteLine(wheelValues[Global.Position]);
                        //contestant[cnum].winnings = 0;
                        for (byte f = 0; f < 3; ++f)
                        {
                            PickALetter(puzzle, wheelValues, currentPuzzle, contestant, cnum, z);
                        }
                        contestant[x].special = wheelValues[Global.Position];
                        BuyAvowel(puzzle, contestant[x], currentPuzzle, y);

                        break;
                    default:
                        Console.WriteLine("\n\n$" + wheelValues[Global.Position] + ".00");
                        contestant[x].winnings += Convert.ToInt32(wheelValues[Global.Position]);
                        for (byte f = 0; f < 3; ++f)
                        {
                            PickALetter(puzzle, wheelValues, currentPuzzle, contestant, cnum, z);
                        }
                        BuyAvowel(puzzle, contestant[x], currentPuzzle, y);

                        break;
                }
            }
            else
            {

                switch (Global.Position)
                {
                    case 3: //Player landed on Lose a turn
                        Global.player = 0;
                        Console.WriteLine(wheelValues[Global.Position]);
                        break;
                    case 23: //Player landed on BANKRUPT
                        Console.WriteLine(wheelValues[Global.Position]);
                        contestant[cnum].winnings = 0;
                        Global.player = 0;
                        break;
                    default:
                        Console.WriteLine("\n\n$" + wheelValues[Global.Position] + ".00");
                        PickALetter(puzzle, wheelValues, currentPuzzle, contestant, cnum, z);
                        break;
                }
            }
        }//Spin Wheel Terminator


        /**********************************************************************
        *
        * Function to let a user pick a letter
        *        Benjamin Knickelbine
        * ********************************************************************/

        private static void PickALetter(List<Letter> puzzle, string[] wheelValues, Puzzle currentPuzzle, Contestant[] contestant, byte cnum, byte z)
        {
            char input;
            Console.WriteLine("Select a Consonant:");
            try
            {
                input = Convert.ToChar(Console.ReadLine());//user input
            }
            catch (Exception)
            {
                input = '\0';
            }
            input = char.ToUpper(input);
            while (input == 'A' || input == 'E' || input == 'I' || input == 'O' || input == 'U')
            {
                Console.WriteLine("That is a vowel! Please select a Consonant:");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());//user input
                }
                catch (Exception)
                {
                    input = '\0';
                }
            }
            while (input == '\0' || !char.IsLetter(input))
            {
                Console.WriteLine("That is not a consonant! Please choose a consonant:");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());//user input
                }
                catch (Exception)
                {
                    input = '\0';
                }
            }
            if (isGuessed(input))
            {
                Global.player = 0;

                Console.WriteLine("The letter {0} has already been guessed!", char.ToUpper(input));
                return;
            }
            setGuessed(input);
            /**********************************************************************
            *
            * Final Round modifications by Rodney Lockhart
            *
            * ********************************************************************/

            if (z == 0)
            {
                Console.WriteLine();
                byte x = revealLetters(puzzle, input, currentPuzzle);
                if (Global.Position == 3 || Global.Position == 23)
                {
                    contestant[cnum].special = wheelValues[Global.Position];
                }
                else
                {
                    int wheelValue = Convert.ToInt32(wheelValues[Global.Position]);
                    contestant[cnum].special = Convert.ToString(wheelValue);
                }
            }
            else
            {
                Console.WriteLine();
                byte x = revealLetters(puzzle, input, currentPuzzle);
                if (Global.Position == 3 || Global.Position == 23)
                {
                    contestant[cnum].winnings = contestant[cnum].winnings;
                }
                int wheelValue = Convert.ToInt32(wheelValues[Global.Position]);
                contestant[cnum].winnings = wheelValue * x + contestant[cnum].winnings;
            }
        }

        /**********************************************************************
        *
        * Function to reveal all locations in the puzzle of a specified letter
        *        Benjamin Knickelbine
        * ********************************************************************/


        public static byte revealLetters(List<Letter> puzzle, char theLetter, Puzzle currentPuzzle)
        {
            byte numRevealed = 0; //Counter variable
            foreach (Letter l in puzzle) //For every letter object
            {
                if (l.PuzLetter == char.ToUpper(theLetter))
                {
                    l.IsVisible = true; //Set it to be visible
                    ++numRevealed; //Increment the counter
                }
            }
            printPuzzle(currentPuzzle);
            if (numRevealed == 0)
            {
                Console.WriteLine("\nSorry there are no {0}'s in the puzzle.", char.ToUpper(theLetter));
            }
            Global.player = numRevealed;
            //Global.LCount -= numRevealed;
            return numRevealed; //Return the number of letters revealed (for money purposes)
        }

        /**********************************************************************
        *
        * Function to print the entire current puzzle
        *        Benjamin Knickelbine
        * ********************************************************************/


        public static void printPuzzle(Puzzle currentPuzzle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;//letter coloring on display
            //For every letter object in the puzzle
            foreach (Letter l in currentPuzzle.puzzleLetters)
            {

                if (l.IsVisible == true) //If the letter is visible
                    Console.Write(l.PuzLetter + " "); //Print it

                else if (l.PuzLetter == ' ') //Otherwise, if it is a space
                {
                    Console.WriteLine(); //Print a new line to separate words
                }

                else if (l.IsVisible == false) //Otherwise, if it is not visible
                {
                    Console.Write("_ "); //Print a placeholder
                }
            }
            Console.ForegroundColor = ConsoleColor.White;//output color
            Console.WriteLine("\n");
        }

        /**********************************************************************
        *
        * Function to fill the boolean array with all false values (beginning of round)
        *        Benjamin Knickelbine
        * ********************************************************************/


        //Function to fill the boolean array with all false values (beginning of round)
        public static void fillGuessed()
        {

            for (int i = 0; i < Global.GuessedLetters.Length; i++)
                Global.GuessedLetters[i] = false;
        }

        /**********************************************************************
        *
        * Function to see whether the current letter has been guessed or not
        *        Benjamin Knickelbine
        * ********************************************************************/


        public static bool isGuessed(char theLetter)
        {
            int location = ((int)char.ToUpper(theLetter)) - 65; //Convert char value to array location
            if (Global.GuessedLetters[location]) //If it has been guessed before
                return true; //Return true
            else
            {
                return false; //Otherwise it hasn't been guessed, return false
            }
        }
        /**********************************************************************
        *
        * Function to set a letter to have been guessed before
        *    Benjamin Knickelbine
        * ********************************************************************/

        public static void setGuessed(char theLetter)
        {
            int location = ((int)char.ToUpper(theLetter)) - 65; //Convert char value to array location
            Global.GuessedLetters[location] = true; //Set the location to be true
        }

        /**********************************************************************
        *
        * Function to allow a user to solve for a puzzle
        *    Benjamin Knickelbine
        * ********************************************************************/


        public static bool solvePuzzle(List<Letter> statement, byte y, Puzzle currentPuzzle, Contestant[] contestant, byte x)
        {
            Console.Write("Please enter the correct answer to the puzzle: ");
            string userGuess = Console.ReadLine().ToUpper();//user input

            if (userGuess.Length == 0)
            {

                userGuess = "*Empty Guess*";

            }

            bool isCorrect = true;
            for (int i = 0; i < statement.Count; i++)
            {

                if (i >= userGuess.Count())
                {
                    isCorrect = false;
                    break;
                }


                if (userGuess[i] != statement[i].PuzLetter)
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect)
            {
                Console.Clear(); //Clear the screen
                Console.ForegroundColor = ConsoleColor.Green;//letter coloring on display
                Console.WriteLine("That's CORRECT!\n");
                Console.ForegroundColor = ConsoleColor.Red;//letter coloring on display
                for (int i = 0; i < statement.Count; i++)
                {
                    Console.Write(userGuess[i]);
                }

                /**********************************************************************
                *
                * Final Round modifications by Rodney Lockhart
                *
                * ********************************************************************/

                if (y == 99)
                {

                    Global.isPuzzleSolved = true;

                    contestant[x].winnings = contestant[x].RoundWinnings + contestant[x].winnings;

                    Console.Clear();
                    printWinner();

                    Console.WriteLine("\n\n\t\tCONGRATULATIONS {0}", contestant[x].Name);//output
                    Console.WriteLine("\t\tYOU'VE WON");//output
                    if (contestant[x].special == "SPORTS CAR" || contestant[x].special == "TRIP TO HAWAII")
                        Console.WriteLine("\t\t$" + contestant[x].winnings + ".00 AND A " + contestant[x].special + "!");//output
                    else
                    {

                        Console.WriteLine("\t\t$" + (contestant[x].winnings) + ".00!");

                    }

                    return true;
                }
                else
                {
                    contestant[x].RoundWinnings = contestant[x].RoundWinnings + contestant[x].winnings;
                    contestant[x].RoundsWon++;
                    for (byte iv = 0; iv < Global.CCount; ++iv)
                    {
                        contestant[iv].winnings = 0;
                    }

                    System.Threading.Thread.Sleep(3000); //Pause the game for 3 seconds
                    Console.Clear(); //Clear the screen
                    Console.ForegroundColor = ConsoleColor.Yellow;//letter coloring on display
                    Console.WriteLine("That ends round " + (y + 1));//output
                    System.Threading.Thread.Sleep(3000); //Pause the game for 3 seconds
                    Global.isPuzzleSolved = true;
                    return true;
                }
            }
            else
            {

                if(y== 99)
                {

                    return false;

                }

                Console.WriteLine("I'm sorry, that is not the correct answer.");//output
                Global.player = 0;
                return false;
            }
        }

        /************************************************

        *
        * Function to calculate which contestant has the most winnings
        * If there is a tie, calculate most wins
        *
        *
        * **********************************************/

        public static Contestant tabulateScoresRounds(Contestant[] contestant)
        {

            bool isTied = false;
            byte largest = 0;
            int tie = -1;
            for (byte i = 1; i < contestant.Length; i++)
            {
                if (contestant[i].RoundWinnings > contestant[largest].RoundWinnings)
                    largest = i;
            }

            for (int i = 0; i < contestant.Length; i++)
            {
                if (i == largest)
                    continue;

                if (contestant[i].RoundWinnings == contestant[largest].RoundWinnings)
                {
                    isTied = true;
                    tie = i;
                }
            }

            if (isTied)
            {
                Console.WriteLine("There's two players tied at ${0} each!", contestant[largest].RoundWinnings);
                if (tie != -1 && contestant[largest].RoundsWon > contestant[tie].RoundsWon)
                {
                    Console.WriteLine("Because {0} won more rounds, they are moving on to the bonus round!",
                                      contestant[largest].Name);//output
                    System.Threading.Thread.Sleep(5000);
                    Global.finalist = largest;
                    return contestant[largest];
                }
                Console.WriteLine("Because {0} won more rounds, they are moving on to the bonus round!",
                                  contestant[tie].Name);//output
                System.Threading.Thread.Sleep(5000);
                Global.finalist = (byte)tie;
                return contestant[tie];
            }

            Console.WriteLine(
                "The contestant with the largest winnings is {0}!\nThey will be moving on to the bonus round!",
                contestant[largest].Name);
            System.Threading.Thread.Sleep(5000);
            Global.finalist = largest;
            return contestant[largest];
        }


        /************************************************
        *
        *
        * Function to animate wheel spinning
        * Created by Tiffany
        *
        * **********************************************/


        public static void animateWheel(string[] wheelValues, byte startPosition, byte rotations, byte position)
        {
            Console.Clear();//Clears the screen

            if (rotations > 0)
            {
                for (int i = 0; i <= rotations; i++)
                {
                    for (int j = 0; j < 24; j++)
                    {
                        Type type = typeof(ConsoleColor);

                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, Enum.GetNames(type)[(j % 15) + 1]);
                        Console.WriteLine(wheelValues[j]);//display array index value

                        if (i == rotations)
                        {
                            System.Threading.Thread.Sleep(55);//pause
                            Console.Clear();//Clears the screen
                            continue;
                        }


                        System.Threading.Thread.Sleep(35);//pause
                        Console.Clear();//Clears the screen
                    }
                }

                for (int j = startPosition; j != position; j++)
                {
                    if (j >= 24)
                    {

                        j -= 24;
                        break;

                    }



                    Type type = typeof(ConsoleColor);

                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, Enum.GetNames(type)[(j % 15) + 1]);
                    Console.WriteLine(wheelValues[j]);//display array index value

                    System.Threading.Thread.Sleep(85);//pause
                    Console.Clear();//Clears the screen
                }

                if (wheelValues[position] == "Lose a turn")
                {

                    printLoseTurn();
                    System.Threading.Thread.Sleep(2000);//1 sec pause
                    Console.Clear();//Clears the screen
                    return;

                }
                else if (wheelValues[position] == "BANKRUPT")
                {

                    printBankrupt();
                    System.Threading.Thread.Sleep(2000);//1 sec pause
                    Console.Clear();//Clears the screen
                    return;

                }

                Console.WriteLine(wheelValues[position]);//display array index value
                System.Threading.Thread.Sleep(1000);//1 sec pause
                Console.ForegroundColor = ConsoleColor.White;//letter coloring on display
                Console.Clear();//Clears the screen
                return;
            }

            for (int j = startPosition; j != position; j++)
            {
                if (j >= 24)
                {

                    j -= 24;
                    break;

                }
                Type type = typeof(ConsoleColor);

                Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, Enum.GetNames(type)[(j % 15) + 1]);
                Console.WriteLine(wheelValues[j]);//display array index values

                System.Threading.Thread.Sleep(185);//pause
                Console.Clear();//Clears the screen
            }

            if (wheelValues[position] == "Lose a turn")
            {

                printLoseTurn();
                System.Threading.Thread.Sleep(2000);//1 sec pause
                Console.Clear();
                return;

            }
            else if (wheelValues[position] == "BANKRUPT")
            {

                printBankrupt();
                System.Threading.Thread.Sleep(2000);//1 sec pause
                Console.Clear();
                return;

            }

            Console.WriteLine(wheelValues[position]);//display array index value
            System.Threading.Thread.Sleep(1000);//1 sec pause
            Console.ForegroundColor = ConsoleColor.White;//letter coloring on display
            Console.Clear();//Clears the screen
        }


        /************************************************
        *
        * Function to print Lose a turn message
        * Created by Tiffany
        *
        * **********************************************/

        public static void printLoseTurn()
        {
            //Graphical display
            Console.ForegroundColor = ConsoleColor.Red;//letter coloring on display
            Console.WriteLine(" _____                       _______   _______                    ");
            Console.WriteLine("|     |_.-----.-----.-----. |   _   | |_     _|.--.--.----.-----.  ");
            Console.WriteLine("|       |  _  |__ --|  -__| |       |   |   |  |  |  |   _|     |  ");
            Console.WriteLine("|_______|_____|_____|_____| |___|___|   |___|  |_____|__| |__|__| \n");
            Console.ForegroundColor = ConsoleColor.White;//letter coloring on display

        }

        /************************************************

        *
        * Function to print bankrupt message
        * Created by Tiffany
        *
        * **********************************************/


        public static void printBankrupt()
        {
            //Graphical display
            Console.ForegroundColor = ConsoleColor.DarkGray;//letter coloring on display
            Console.WriteLine("  d8888b.  .d8b.  d8b   db db   dD d8888b. db    db d8888b. d888888b ");
            Console.WriteLine("  88  `8D d8' `8b 888o  88 88 ,8P' 88  `8D 88    88 88  `8D `~~88~~' ");
            Console.ForegroundColor = ConsoleColor.Gray;//letter coloring on display
            Console.WriteLine("  88oooY' 88ooo88 88V8o 88 88,8P   88oobY' 88    88 88oodD'    88 ");
            Console.WriteLine("  88~~~b. 88~~~88 88 V8o88 88`8b   88`8b   88    88 88~~~      88 ");
            Console.ForegroundColor = ConsoleColor.White;//letter coloring on display
            Console.WriteLine("  88   8D 88   88 88  V888 88 `88. 88 `88. 88b  d88 88         88   ");
            Console.WriteLine("  Y8888P' YP   YP VP   V8P YP   YD 88   YD ~Y8888P' 88         YP ");

        }


        /************************************************

        *
        * Function to print winner message
        * Created by Tiffany
        *
        * **********************************************/

        public static void printWinner()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ||   / |  / /                                         //  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ||  /  | / / ( )   __       __      ___      __      //  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" || / /||/ / / / //   ) ) //   ) ) //___) ) //  ) )  //   ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ||/ / |  / / / //   / / //   / / //       //             ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" |  /  | / / / //   / / //   / / ((____   //       //     ");
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}


//3 consanants and one vowel

