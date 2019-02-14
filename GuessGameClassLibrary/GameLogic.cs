using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
/// GuessGameClassLibrary : GameLogic.cs
/// Jieun Kwon
/// Jan 24, 2019
*/

/// <summary>
/// GuessGameClassLibrary is the logical library for guessing a number 
/// </summary>
namespace GuessGameClassLibrary
{
    /// <summary>
    /// Main rules and logic for Game
    /// 1. Generating a random number
    /// 2. Comparing user guess number to a random number 
    /// 3. Returing the result
    /// </summary>
    public class GameLogic
    {
        
        /// <summary>
        ///  private field rNum is for generating a random number
        /// </summary>
        private int rNum;

        /// <summary>
        /// public field uAttemp is for storing user attemps
        /// </summary>
        private int uAttemp;

        /// <summary>
        /// public field UAttemp is for storing user attemps
        /// </summary>
        public int UAttemp
        {
            // get and set
            get { return uAttemp; }
            set { uAttemp = 0;    }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="guessRange">GuessRange type parameter for the random range </param>
        public GameLogic (GuessRange guessRange)
        {
            // initialize rNum with random number
            // when random is created, the last num is not included. so uBound will be added 1 
            rNum = new Random().Next(guessRange.LBound, guessRange.UBound + 1);
        }

        /// <summary>
        /// public method VerifyGuess(int) : to check uNum and return result of GameState
        /// </summary>
        /// <param name="uNum">the number that user entered to guess</param>
        /// <returns>VerifyGuess returns a result as GameState type</returns>
        public GameState VerifyGuess (int uNum)
        {
            // return value
            GameState result;

            // add user attemp
            uAttemp ++;

            // guessing is correct 
            if (rNum == uNum) 
                result = GameState.GUESS_CORRECT; 
            
            // high
            else if (rNum < uNum)
                result = GameState.GUESS_TOO_HIGH;

            // low
            else 
                result = GameState.GUESS_TOO_LOW;
            
            return result;

        }

        
    }
}
