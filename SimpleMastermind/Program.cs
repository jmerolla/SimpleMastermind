using System;

namespace SimpleMastermind
{
    /// <summary>
    /// Author: Jessica Merolla     Date: 3/13/2021
    /// 
    /// Initiates the gameplay of mastermind
    /// </summary>
    class Program
    {
        /// <summary>
        ///  Creates a new MastermindHandler and initializes a new game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MastermindHandler mastermindGame = new MastermindHandler();
            mastermindGame.startup();
            mastermindGame.initializeGame();

        }
    }
}
