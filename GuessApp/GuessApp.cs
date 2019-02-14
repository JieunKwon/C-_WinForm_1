using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuessGameClassLibrary;

/*
/// GuessApp : Form1.cs
/// Jieun Kwon
/// Jan 17, 2019
/// Final Edit date: Jan 25, 2019

/// namespace : GuessApp
/// This app is the guessing number game. 
/// 1) User can change the range for game. 
/// 2) User can try this game with limit number of attemps. 
/// 3) User can try new game if they want 
*/

namespace GuessApp
{
    /// <summary>
    /// GuessApp : Main Form
    /// </summary>
    public partial class GuessApp : Form
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

        /// <summary>
        /// declaration of object GuessRange
        /// </summary>
        GuessRange guessRange;

        /// <summary>
        /// declaration of object GameLogic
        /// </summary>
        GameLogic gameLogic;

        /// <summary>
        /// Form1 Constructor
        /// </summary>
        public GuessApp()
        {
             
            InitializeComponent();

            // call method to set default game environment  
            StartGame();

        }

        /// <summary>
        /// private method : set default game environment 1) game range and logic to start game, and set default value for component
        /// </summary>
        private void StartGame()
        {
            // declaration of GuessRange with default range value
            guessRange = new GuessRange(DEFAULT_LOWER_BOUND, DEFAULT_UPPER_BOUND);

            // declaration of GameLogic with param guessRange
            gameLogic = new GameLogic(guessRange);

            // set default properties  
            bGuess.Enabled = true;
            bChange.Enabled = true;
            bNew.Enabled = true;
            txtGuess.Text = "";
            txtLower.Text = "";
            txtUpper.Text = "";
            lblResult.ForeColor = Color.Black;

            // set lblResult text
            lblResult.Text = "You can try " + GAME_ATTEMP_LIMIT + " times\r\nPlease enter a number between " + DEFAULT_LOWER_BOUND + " and " + DEFAULT_UPPER_BOUND;

        }
 
        /// <summary>
        /// Button Event when Guess Button is clicked
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void bGuess_Click(object sender, EventArgs e)
        {
            // make bChange button disable to avoid to change range during the current game 
            bChange.Enabled = false;

            // uNum is textBox value user entered
            int uNum; 

            // verification for null value
            if (!string.IsNullOrEmpty(txtGuess.Text))
            {
                // verification for a number value
                if (int.TryParse(txtGuess.Text, out uNum))
                { 
                     
                    uNum = int.Parse(txtGuess.Text);             

                    // get game result from gameLogic.VerifyGuess with uNum param
                    GameState gameState = gameLogic.VerifyGuess(uNum);
                     
                    // check game result by gameState, then change textbox value and color
                    switch (gameState)
                    {
                     
                        // GUESS_CORRECT
                        case GameState.GUESS_CORRECT:

                            lblResult.Text = "Your guess is correct";
                            lblResult.Text += "\r\nYou Win!";
                            lblResult.ForeColor = Color.Red;
                            bGuess.Enabled = false;             // if guess is correct, make guess button enable 
                            break;

                        // GUESS_TOO_LOW
                        case GameState.GUESS_TOO_LOW:
                            lblResult.Text = "Your guess is too low";
                            lblResult.ForeColor = Color.Black;

                            // check user attemps
                            if (gameLogic.UAttemp < GAME_ATTEMP_LIMIT)
                            {
                                lblResult.Text += "\r\nRemaining Attemps : " + (GAME_ATTEMP_LIMIT - gameLogic.UAttemp);
                            }
                            else
                            { 
                                lblResult.Text += "\r\nGame Over!";
                                bGuess.Enabled = false;
                            }

                            break;

                        // GUESS_TOO_HIGH
                        case GameState.GUESS_TOO_HIGH:
                            lblResult.Text = "Your guess is too high";
                            lblResult.ForeColor = Color.Black;

                            // check user attemps
                            if (gameLogic.UAttemp < GAME_ATTEMP_LIMIT)
                            {
                                lblResult.Text += "\r\nRemaining Attemps : " + (GAME_ATTEMP_LIMIT - gameLogic.UAttemp);
                            }
                            else
                            {
                                lblResult.Text += "\r\nGame Over!";
                                bGuess.Enabled = false;
                            }

                            break;
                    }
                      
                }
                else
                {
                    lblResult.Text = "Please enter a number";
                    lblResult.ForeColor = Color.Red;
                }
                 
            }
        }

        /// <summary>
        /// Button Event to change the guess range 
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void bChange_Click(object sender, EventArgs e)
        {
            // set lower value with textbox value
            if(!string.IsNullOrEmpty(txtLower.Text))
                guessRange.LBound = int.Parse(txtLower.Text);

            // set upper value with textbox value
            if (!string.IsNullOrEmpty(txtUpper.Text))
                guessRange.UBound = int.Parse(txtUpper.Text);

            // set label text with new range info
            lblResult.Text = "Please enter a number between " + guessRange.LBound + " and " + guessRange.UBound;
            lblResult.ForeColor = Color.Black;

            // remove textboxes' text
            txtLower.Text = "";
            txtUpper.Text = "";
        }

        /// <summary>
        /// New Game button click event : this event allows to reset game
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void bNew_Click(object sender, EventArgs e)
        {
            // call method for new game
            StartGame();

        }
    }
}
