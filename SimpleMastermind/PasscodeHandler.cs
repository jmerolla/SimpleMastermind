using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMastermind
{
    /// <summary>
    ///  Author: Jessica Merolla    Date: 3/13/2021
    ///  
    /// Handles the logic behind setting the passcode and comparing
    /// the user's guesses to the passcode
    /// </summary>
    class PasscodeHandler
    {
        private List<int> passcode = new List<int>();   //stores the passcode
        String stringPasscode;  //the passcode, stored as a string (for display)
        Random rand = new Random(); //used to generate the password digits between 1 and 6

        /// <summary>
        ///  Generates a four digit passcode with digits between 1 and 6
        /// </summary>
        public void generatePasscode()
        {
            stringPasscode = "";
            passcode.Clear();
            for (int i = 0; i < 4; i++)
            {
               passcode.Add(rand.Next(1, 7));
              // Console.WriteLine(passcode[i]);  //for testing
               stringPasscode += passcode[i];
            }
           
        }

        /// <summary>
        ///  Returns the passcode as a string
        /// </summary>
        /// <returns>A string holding the passcode</returns>
        public string getPasscode()
        {
            return stringPasscode;
        }

        /// <summary>
        /// takes in the user's guess and evaluates if this is the correct password,
        /// and how close it is to being correct
        /// </summary>
        /// <param name="guessList"> The list of user's guess digits </param>
        /// <returns>a boolean of whether or not all digits in the list were correct </returns>
        public bool checkGuess(List<int> guessList)
        {
            List<String> clues = new List<String>();
            bool allCorrect = true; //the guess starts out as being fully correct
            for(int i = 0; i<guessList.Count; i++)
            {
                if (passcode.Contains(guessList[i]))    //is the users number in the passcode?
                {
                    //TRUE - in passcode
                    if(passcode[i] == guessList[i]) //is the user's number in the correct spot
                    {
                        //TRUE - in correct position
                        clues.Add("+");
                    }
                    else
                    {
                        //FALSE - in wrong position
                        clues.Add("-");
                        allCorrect = false;
                    }  
                }
                else
                {
                    allCorrect = false;
                }
            }
            //To prevent the clue from being in order:

            //first look for any + signs in the clue and print them to the console
            for(int i = 0; i< clues.Count; i++)
            {
                if(clues[i] == "+")
                {
                    Console.Write("+");
                }
            }
            //then print any - signs in the clue
            for (int i = 0; i < clues.Count; i++)
            {
                if (clues[i] == "-")
                {
                    Console.Write("-");
                }
            }

            Console.WriteLine("\n");
            return allCorrect;  //return whether or not the guess was correct
        }
    }
}
