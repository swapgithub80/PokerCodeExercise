using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameConsoleApp.Common
{
    /// <summary>
    /// Constants file to store errormessages, Player name and winning values. 
    /// </summary>
    public class PokerConstants
    {
        #region Error Messages
        public const string InvalidInputMessage = "Invalid Input";
        public const string InvalidInputLengthMessage = "Invalid Input Length";
        public const string InvalidInputSuitsMessage = "Invalid Input Suits";
        public const string InvalidInputDuplicatesMessage = "Duplicate pair of cards present in the input";
        public const string InvalidInputRanksMessage = "Invalid Input Ranks";
        #endregion

        #region Player
        public const string Player1 = "LeftHand";
        public const string Player2 = "RightHand";
        #endregion

        #region Winner Messages

        public const string LeftHandWins = "Left Hand Wins.";
        public const string RightHandWins = "Right Hand Wins.";
        public const string Draw = "Draw.";
        #endregion

    }
}
