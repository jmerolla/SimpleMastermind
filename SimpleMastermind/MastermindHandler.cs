using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleMastermind
{
    /// <summary>
    /// Author: Jessica Merolla     Date: 3/13/2021
    /// 
    /// Handles the gameplay logic of Mastermind
    /// </summary>
    class MastermindHandler
    {
        int guesses;    //amount of guesses user is allowed to have
        PasscodeHandler passcodeHandler = new PasscodeHandler();    //handles passcode methods
        bool gameWon;   //tracks if the code has been guessed correctly

        public void startup()
        {
            Console.WriteLine("------Welcome to Mastermind!------");
            Console.WriteLine("");
            Console.WriteLine("Do you want to see the rules? ----");
            string wantRules = getYesOrNo();
            //display rules if user selected yes
            if (wantRules == "y")
            {
                getRules();
            }
        }

        /// <summary>
        /// Prepare a new game of mastermind
        /// </summary>
        public void initializeGame()
        {
            //generate a password for the new game
            passcodeHandler.generatePasscode();

            //start the guessing
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("----------------- Game Start --------------------");
            playGame();


        }

        /// <summary>
        /// Tracks the user's turns and whether or not they have won
        /// At the end, will ask the user if they want to play again
        /// </summary>
        public void playGame()
        {
            guesses = 10;
            gameWon = false;   //game has not been won 
            while (guesses > 0 && gameWon == false) //loops until out of guesses, or game has been won
            {
               
                Console.WriteLine("\n** Guesses left: " + guesses + "  **\n");
                gameWon = takeTurn();   //take a turn, find out if the user has won
                guesses--;  //turn is over, 1 less guess is allowed
                Console.WriteLine("**************************************************");
            }

            Console.WriteLine("\n\n");
            if(gameWon == true) //display win message
            {
                Console.WriteLine("YOU WON!");
            }
            else //display loss message
            {
                Console.WriteLine("YOU LOST");
                Console.WriteLine("The passcode was: " + passcodeHandler.getPasscode());
            }

            //determine if user wants to play again
            Console.WriteLine("-------------------------------------------------");
            Console.Write("Play again? Yes (y) or No (n): ");
            string wantNewGame = getYesOrNo();

            //display rules if user selected yes
            if (wantNewGame == "y")
            {
                initializeGame();
            }
            else
            {
                Console.WriteLine("\nThanks for playing!\n");
            }
        }

        /// <summary>
        ///     The logic of the user's turn.
        ///     Takes in a user's guess and shows how accurate the user was.
        /// </summary>
        /// <returns> True if the user has guessed correctly,
        ///           False if the user has guessed incorrectly
        /// </returns>
        public bool takeTurn()
        {
            bool validNumberRange = true;
            List<int> intList;  //will store the user's guess
            Console.Write("Enter the passcode: ");

            //loops until the user enters a valid guess
            do
            {
                var input = Console.ReadLine(); //the user's guess
               
                
                try //attempt to parse player input into a list of ints
                {
                    intList = input.Select(x => Convert.ToInt32(x.ToString())).ToList();
                    if (intList.Count == 4) {   //parse was successful, check length
                        //TODO check numbers are between 1 and 6
                        //One last check to see if the values entered are between 1 and 6
                        for(int i = 0; i< intList.Count; i++)
                        {
                           
                            if((intList[i]<1) || (intList[i] > 6)){
                                validNumberRange = false;
                            }
                        }

                        if(validNumberRange == true)
                        {
                            //valid guess, break loop
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Numbers in guess must be between 1 and 6 (inclusive)");
                        }
                        
                    }
                    else //guess was not 4 digits
                    {
                        Console.WriteLine("The passcode must be 4 digits consisting of numbers between 1 and 6.\n");
                    }
                } catch(Exception e)    //parsing the guess to an int failed
                {
                    Console.WriteLine("The passcode must be a number.\n");
                }
                
                


                //ask the user to re-enter a guess
               Console.Write("Try again: ");
                
                
            } while (true);


            //Console.WriteLine("\nGuess worked");  //-for testing
            Console.Write("\nClue: ");
            return passcodeHandler.checkGuess(intList); //evaluation occurs in the passcodeHandler
                                                        //checks if the guess was correct
        }
     
        /// <summary>
        ///  Prints the rules of mastermind
        /// </summary>
        public void getRules() {
            Console.WriteLine(" ");
            Console.WriteLine("Rules -------------------------------------------");
            Console.WriteLine("Try to guess the passcode!");
            Console.WriteLine("The passcode consists of 4 digits between 1 and 6 (inclusive)\n\n");
            Console.WriteLine("You will get a clue after each turn:");
            Console.WriteLine("+ = Correct number in correct spot");
            Console.WriteLine("- = Correct number incorrect spot");
            Console.WriteLine("No symbol means the number was completely incorrect");
            Console.WriteLine("NOTE: The order of the clue does not correspond to the guess\n\n");
            Console.WriteLine("You have 10 guesses.");
            Console.WriteLine("Good luck!");
        }

        /// <summary>
        /// Gets the user's answer to a yes or no question
        /// </summary>
        /// <returns>A string with either "y" or "n" </returns>
        public string getYesOrNo()
        {
            string theResponse; //the user's answer, stored as a string
            do
            {
                Console.Write("Yes (y) or No (n): ");
                theResponse = Console.ReadLine();
                var lowercaseResponse = theResponse?.ToLower();   //if not a null value, make lowercase
                if ((lowercaseResponse == "y") || (lowercaseResponse == "n"))
                {
                    theResponse = lowercaseResponse;
                    break;
                }

            } while (true);

            return theResponse;
        }
    }
}
