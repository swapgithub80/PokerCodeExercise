﻿using PokerGameConsoleApp.Model;
using PokerGameConsoleApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using PokerGameConsoleApp.Enums;


namespace PokerGameConsoleApp
{
    public class PokerHands
    {
        public List<Card> Cards { get; set; }
        public HandType handcategory;

        /// <summary>
        /// 1. initialize the Card list  
        /// 2.split the handString into CardStrings
        /// 3.adding new Cards to our Card list
        /// 4. Get the Handcategory for the cardlist.
        /// </summary>

        public PokerHands(string handString)
        {

            this.Cards = new List<Card>();
            List<string> tempList = handString.Split(' ').ToList();
            for (int i = 0; i <= 4; i++)
            {
                this.Cards.Add(new Card(tempList[i]));
            }
            handcategory = GetRank();
        }

        /// <summary>
        /// Splits the input string to lefthand and righthand 
        /// </summary>
        /// <param name="pokerHands"></param>
        /// <returns></returns>
        public static string PlayerCards(string pokerHands)
        {
            Console.WriteLine("\n" + PokerConstants.Player1 + "\n");
            Console.WriteLine(pokerHands.Substring(0, 14) + "\n");
            Console.WriteLine(PokerConstants.Player2 + "\n");
            Console.WriteLine(pokerHands.Substring(15) + "\n");
            return CalculateWinner(pokerHands);
        }

        /// <summary>
        /// Takes the input of the players and Compares the values.
        /// </summary>
        /// <param name="hands"></param>
        /// <returns> Returns the winner of the game.</returns>
        public static string CalculateWinner(string hands)
        {
            string retval = string.Empty;
            try
            {
                PokerHands lefthand = new PokerHands(hands.Substring(0, 14));
                PokerHands righthand = new PokerHands(hands.Substring(15));
                switch (lefthand.compareTo(righthand))
                {
                    case 1:
                        retval = PokerConstants.LeftHandWins;
                        break;
                    case -1:
                        retval = PokerConstants.RightHandWins;
                        break;
                    case 0:
                        retval = PokerConstants.Draw;
                        break;
                }


            }
            catch (Exception ex)
            {
                retval = ex.Message;
            }

            return retval;
        }

        /// <summary>
        /// Compares the left hand and right hand.
        /// </summary>
        /// <param name="righthand"></param>
        /// <returns>Returns 1 or -1 or 0</returns>
        public int compareTo(PokerHands righthand)
        {
            if (handcategory < righthand.handcategory)
            {
                return 1;
            }
            if (handcategory > righthand.handcategory)
            {
                return -1;
            }
            if (handcategory == righthand.handcategory)
            {
                return Cards.Max(c => c.Rank).CompareTo(righthand.Cards.Max(c => c.Rank));
            }
            return 0;
        }

        /// <summary>
        /// Selects the rank and puts them in order regardless of suit. 
        /// If both IsFlush and the temp1 string are both true, 
        /// then the dealt hand will be recognized as a royal flush.
        /// </summary>
        /// <returns>true if  royal flush</returns>
        public bool RoyalFlush()
        {

            string temp = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string temp1 = "1011121314";
            if (IsFlush() && temp.Contains(temp1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Selects the suit and gets the count of distinct suit. 
        /// If all the 5 cards are of the same suit, 
        /// then the dealt hand will be recognized as a flush.
        /// </summary>
        /// <returns>true if  flush</returns>
        public bool IsFlush()
        {

            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;

        }

        /// <summary>
        /// Groups by rank and if count of any suit is 2  
        /// then the dealt hand will be recognized as a pair.
        /// </summary>
        /// <returns>true if has pair</returns>
        public bool HasPair()
        {

            return this.Cards.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Any();
        }

        /// <summary>
        /// Selects the rank and puts them in order regardless of suit. 
        /// If the disitnct rank count is 3  
        /// then the dealt hand will be recognized as a pair.
        /// </summary>
        /// <returns>true if 2 pair</returns>
        public bool TwoPair()
        {

            return this.Cards.Select(x => x.Rank).Distinct().Count() == 3;
        }

        public bool Straight()
        {

            string temp = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string temp1 = "234567891011121314";
            return temp1.Contains(temp);
        }

        /// <summary>
        /// If the count of the cards is 3  
        /// then the dealt hand will be recognized as a three of a kind.
        /// </summary>
        /// <returns>true if 3 of a kind</returns>

        public bool ThreeOfaKind()
        {

            IEnumerable<IGrouping<int, Card>> tmp = this.Cards.GroupBy(x => x.Rank);
            return tmp.Where(x => x.Count() == 3).Any();
        }

        /// <summary>
        /// If the count of the cards is 4 reardless of suit  
        /// then the dealt hand will be recognized as a four of a kind.
        /// </summary>
        /// <returns>true if four of a kind</returns>

        public bool FourOfaKind()
        {

            IEnumerable<IGrouping<int, Card>> tmp = this.Cards.GroupBy(x => x.Rank);
            return tmp.Where(x => x.Count() == 4).Any();
        }

        /// <summary>
        /// If within the cards dealt there is three 
        /// of a kind and a pair, then it will be recognized 
        /// as a full house. 
        /// </summary>
        /// <returns>true if fullhouse.</returns>

        public bool FullHouse()
        {

            if (ThreeOfaKind() && HasPair())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// //If both IsFlush and Straight are both true, then 
        /// the dealt hand will be recognized as a straight flush.
        /// </summary>
        /// <returns></returns>
        public bool StraightFlush()
        {

            if (IsFlush() && Straight())
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        /// <summary>
        ///  Checks for the handtype of the cardlist of each player
        /// </summary>
        /// <returns> Handtype</returns>
        public HandType GetRank()
        {
            HandType retval = HandType.HighCard;

            if (RoyalFlush())
            {
                retval = HandType.RoyalFlush;
            }
            else if (FourOfaKind())
            {
                retval = HandType.FourOfaKind;
            }
            else if (FullHouse())
            {
                retval = HandType.FullHouse;
            }
            else if (ThreeOfaKind())
            {
                retval = HandType.ThreeOfaKind;
            }
            else if (StraightFlush())
            {
                retval = HandType.StraightFlush;
            }
            else if (Straight())
            {
                retval = HandType.Straight;
            }
            else if (IsFlush())
            {
                retval = HandType.Flush;
            }
            else if (TwoPair())
            {
                retval = HandType.TwoOfaKind;
            }
            else if (HasPair())
            {
                retval = HandType.Pair;
            }
            return retval;
        }
    }
}

