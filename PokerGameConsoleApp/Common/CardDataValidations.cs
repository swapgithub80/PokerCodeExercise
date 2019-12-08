using PokerGameConsoleApp.Enums;
using System;
using System.ComponentModel;
using System.Linq;

namespace PokerGameConsoleApp.Common
{

    /// <summary>
    /// Evaluates the poker hand and checks for validations.
    /// </summary>
  public  class CardDataValidations
    {
        /// <summary>
        /// Checks if the input entered is a valid input.
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>Analyse the game if true else throw error</returns>
        public static string EvaluatePokerHands(string pokerHandsData)
        {
            if (!CheckForPokerCardHandsDataIsValid(pokerHandsData))
            {
                throw new Exception(PokerConstants.InvalidInputMessage);
            }

            else
            {

                return PokerHands.PlayerCards(pokerHandsData);
            }
        }
        /// <summary>
        /// CHecks for input for length, null,rank, suit
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>true or false</returns>
            public static bool CheckForPokerCardHandsDataIsValid(string pokerHandsData)
        {
            if (string.IsNullOrEmpty(pokerHandsData))
            {
                return false;
            }
            string[] pokerHands = pokerHandsData.ToUpper().Split(' ');
            if (pokerHands == null)
            {
                return false;
            }
            bool isPokerHandsInputValid = CheckforPokerHandsCountAndDuplicateCards(pokerHands) && CheckForPokerCardsRanksIsValid(pokerHands)
                                          && CheckForPokerCardsSuitsIsValid(pokerHands);
            if (!isPokerHandsInputValid)
            {
                throw new Exception(PokerConstants.InvalidInputLengthMessage);
            }
            return true;

        }


        /// <summary>
        /// Checks if inout has duplicate cards.
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>true or false</returns>
        private static bool CheckforPokerHandsCountAndDuplicateCards(string[] pokerHandsData)
        {
            if (pokerHandsData.Length != 10)
            {
                throw new Exception(PokerConstants.InvalidInputLengthMessage);
            }
            if (pokerHandsData.Distinct().Count() != 10)
            {
                throw new Exception(PokerConstants.InvalidInputDuplicatesMessage);

            }
            return true;
        }

        /// <summary>
        /// Checks  input for valid rank.
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>true or false</returns>
        private static bool CheckForPokerCardsRanksIsValid(string[] pokerHandsData)
        {
            bool isValidPokerCardsRank = pokerHandsData
                .Where(s => !string.IsNullOrEmpty(s) && CheckCardIsPresentInEnumBasedOnEnumType(typeof(Ranks), s[0].ToString())).Select(s => s[0]).Count() == 10;
            if (!isValidPokerCardsRank)
            {
                throw new Exception(PokerConstants.InvalidInputRanksMessage);

            }
            return true;
        }


        /// <summary>
        /// Checks  input for valid suit.
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>true or false</returns>
        private static bool CheckForPokerCardsSuitsIsValid(string[] pokerHandsData)
        {
            bool isValidPokerCardsSuit = pokerHandsData
                                             .Where(s => !string.IsNullOrEmpty(s) &&
                                                         CheckCardIsPresentInEnumBasedOnEnumType(typeof(Suits), s[1].ToString())).Select(s => s[1]).Count() == 10;
            if (!isValidPokerCardsSuit)
            {
                throw new Exception(PokerConstants.InvalidInputSuitsMessage);

            }
            return true;

        }
        /// <summary>
        /// Check Card Is Present In Enum Based On EnumType. 
        /// </summary>
        /// <param name="pokerHandsData"></param>
        /// <returns>true or false</returns>
        private static bool CheckCardIsPresentInEnumBasedOnEnumType(Type enumType, string valueToCheck)
        {
            if (enumType == null || string.IsNullOrEmpty(valueToCheck))
            {
                return false;
            }
            var enumValues = enumType.GetEnumValues();
            foreach (var cardValue in enumValues)
            {
                var fieldInfo = enumType.GetField(cardValue.ToString());
                var attributes =
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                var description = attributes.Select(s => s.Description);
                if (description == null)
                {
                    return false;
                }
                if (description.Contains(valueToCheck, StringComparer.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
