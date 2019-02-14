using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
/// GuessGameClassLibrary : GuessRange.cs
/// Jieun Kwon
/// Jan 17, 2019
*/
namespace GuessGameClassLibrary
{
    /// <summary>
    /// Structure to represent the range of random
    /// </summary>
    public struct GuessRange
    {
        /// <summary>
        ///  private field
        ///  lBound : int for lower bound number of range 
        ///  uBound : int for lupper bound number of range 
        /// </summary>
        private int lBound, uBound;

        /// <summary>
        /// public property LBound  for lower bound number of range
        /// </summary>
        public int LBound
        {
            // get and set
            get { return lBound; }
            set {
                if(value <= uBound)
                    lBound = value;
            }
        }

        /// <summary>
        /// public property UBound  for upper bound number of range
        /// </summary>
        public int UBound
        {
            // get and set 
            get { return uBound; }
            set {
                if(value > lBound)
                    uBound = value;
            }            
        }

        /// <summary>
        /// Constructor : Initialize a new instance of GuessRange class with two params for lower bound and upper bound
        /// </summary>
        /// <param name="lb"> parameter for lBound value </param>
        /// <param name="ub"> parameter for uBound value </param>
        public GuessRange (int lb, int ub)
        {
            // validation : upper bound must be bigger than lower bound 
            if(lb < ub)
            {
                lBound = lb;
                uBound = ub;
            }
            // set default range 0 and 10
            else
            {  
                lBound = 0;
                uBound = 10;
            }
        }

    }
}
