using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
// GuessGameClassLibrary : GameState.cs
// Define enumeration for the game state
// Jieun Kwon
// Jan 17, 2019
*/
namespace GuessGameClassLibrary
{
    /// <summary>
    /// Enumeration for describing the game state
    /// 3 status : GUESS_CORRECT(0), GUESS_TOO_LOW(1), GUESS_TOO_HIGH(2) 
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// the guess is correct 
        /// </summary>
        GUESS_CORRECT,
        /// <summary>
        /// the guess is lower 
        /// </summary>
        GUESS_TOO_LOW,
        /// <summary>
        /// the guess is higher
        /// </summary>
        GUESS_TOO_HIGH
    }
}
