using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessGameClassLibrary;

/*
/// GuessConsoleApp : console base of the guessing number game
/// Jieun Kwon
/// Jan 26, 2019
 
/// This app is the guessing number game by command interface. 
/// 1) User can select menu( game/ change range/ exit)  
/// 2) User can try this game with limit number of attemps. 
/// 3) User can try new game if they want 
*/

/// <summary>
/// GuessConsoleApp is console base of the guessing number game
/// </summary>
namespace GuessConsoleApp
{
    public class Program
    {
        /// <summary>
        /// constant fields for the limit number of attempts allowed
        /// </summary>
        public const int GAME_ATTEMP_LIMIT = 3;

        /// <summary>
        /// constant fields for the default lower bounds
        /// </summary>
        public const int DEFAULT_LOWER_BOUND = 0;

        /// <summary>
        ///  constant fields for the default upper bounds
        /// </summary>
        public const int DEFAULT_UPPER_BOUND = 10;
         
        static void Main(string[] args)
        {
             
            /// <summary>
            /// declaration of object GuessRange
            /// </summary>
            GuessRange guessRange;

            /// <summary>
            /// declaration of object GameLogic
            /// </summary>
            GameLogic gameLogic;

            // declaration of GuessRange with default range value
            guessRange = new GuessRange(DEFAULT_LOWER_BOUND, DEFAULT_UPPER_BOUND);
             
            ///////////////////////  Game Start   ///////////////////////////
            int gameOption = 0;
            // game menu option 
            //1 - Start game 
            //2 - Change the numbers range 
            //3 - Exit

            // do loop while selecting exit option
            do
            {
                // 1. providing the game menu
                Console.WriteLine("Enter the game option." +
                    "\n 1 - Start a guessing game bewteen " + guessRange.LBound + " and " + guessRange.UBound +
                    "\n 2 - Change the game range" +
                    "\n 3 - Exit");

                // 2. get game option
                gameOption = int.Parse(Console.ReadLine());

                // Game starts
                if (gameOption == 1)
                {
                    // init of GameLogic with param guessRange
                    gameLogic = new GameLogic(guessRange);

                    // get a number
                    Console.WriteLine("You can try " + GAME_ATTEMP_LIMIT + " times.");

                    // var for game loop
                    bool boolGameLoop = true;

                    // loop while checking user's attemp limit
                    while (boolGameLoop)
                    {
                        Console.WriteLine("Enter a number for the game between " + guessRange.LBound + " and " + guessRange.UBound + ".");

                        int uNum = int.Parse(Console.ReadLine());

                        // get game result from gameLogic.VerifyGuess with uNum param
                        GameState gameState = gameLogic.VerifyGuess(uNum);

                        // check game result by gameState, then change textbox value and color
                        switch (gameState)
                        {

                            // GUESS_CORRECT
                            case GameState.GUESS_CORRECT:

                                Console.WriteLine("Your guess is correct. You Win!");
                                boolGameLoop = false;   // set game exit
                                break;

                            // GUESS_TOO_LOW
                            case GameState.GUESS_TOO_LOW:
                                Console.WriteLine("Your guess is too low.");

                                // check user attemps
                                if (gameLogic.UAttemp < GAME_ATTEMP_LIMIT)
                                {
                                    Console.WriteLine("Remaining Attemps : " + (GAME_ATTEMP_LIMIT - gameLogic.UAttemp));
                                     
                                }
                                else
                                {
                                    Console.WriteLine("Game Over!");
                                    boolGameLoop = false;   // set game exit
                                }
                                 
                                break;

                            // GUESS_TOO_HIGH
                            case GameState.GUESS_TOO_HIGH:

                                Console.WriteLine("Your guess is too high.");

                                // check user attemps
                                if (gameLogic.UAttemp < GAME_ATTEMP_LIMIT)
                                {
                                    Console.WriteLine("Remaining Attemps : " + (GAME_ATTEMP_LIMIT - gameLogic.UAttemp));
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Game Over!");
                                    boolGameLoop = false;   // set game exit
                                }
                                 
                                break;
                        }

                    }
                }
                // change range
                else if (gameOption == 2)
                {
                    // get 2 number for lower and upper range

                    // set lower value with textbox value
                    Console.WriteLine("Enter a number for lower range value.");
                    int lNum = int.Parse(Console.ReadLine());

                    // set lower value with textbox value
                    Console.WriteLine("Enter a number for upper range value. It should be bigger than " + lNum + ".");
                    int uNum = int.Parse(Console.ReadLine());

                    // set upper value 
                    guessRange.LBound = lNum;
                    guessRange.UBound = uNum;

                    // print out and go to option
                    Console.WriteLine("The game range is changed from " + guessRange.LBound + " to " + guessRange.UBound);
                    gameOption = 1;
                }
                // exit game
                else
                {
                    // exit console
                    Environment.Exit(0);
                }

            } while (gameOption == 1);
        }
    }
}
