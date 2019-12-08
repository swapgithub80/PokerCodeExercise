using PokerGameConsoleApp.Model;
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

        public PokerHands(string handString)
        {
            //initialize the Card list 
            this.Cards = new List<Card>();
            //split the handString into CardStrings
            List<string> tempList = handString.Split(' ').ToList();
            for (int i = 0; i <= 4; i++)
            {
                //adding new Cards to our Card list
                this.Cards.Add(new Card(tempList[i]));
               
            }
            handcategory = GetRank();

        }

         public  static string LetsPlay(string pokerHands)
        {
            Console.WriteLine("\n" + PokerConstants.Player1 + "\n");
            Console.WriteLine(pokerHands.Substring(0, 14) + "\n");
            Console.WriteLine(PokerConstants.Player2 + "\n");
            Console.WriteLine(pokerHands.Substring(15) + "\n");
            return CalculateWinner(pokerHands);


        }
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


        public bool RoyalFlush()
        {
            //Selects the rank and puts them in order
            // regardless of suit. 
            string temp = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string temp1 = "1011121314";
            //If both IsFlush and the temp1 string are both true, 
            // then the dealt hand will be recognized 
            // as a royal flush.
            if (IsFlush() && temp.Contains(temp1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsFlush()
        {

            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;

        }
        public bool HasPair()
        {

            return this.Cards.Select(x => x.Rank).Distinct().Count() >=2 && this.Cards.Select(x => x.Rank).Distinct().Count() <=4;
        }

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

        public bool ThreeOfaKind()
        {

            IEnumerable<IGrouping<int, Card>> tmp = this.Cards.GroupBy(x => x.Rank);
            return tmp.Where(x => x.Count() == 3).Any();
        }

        public bool FourOfaKind()
        {

            IEnumerable<IGrouping<int, Card>> tmp = this.Cards.GroupBy(x => x.Rank);
            return tmp.Where(x => x.Count() == 4).Any();
        }

     
        public bool FullHouse()
        {
            //If within the cards dealt there is three 
            // of a kind and a pair, then it will be recognized 
            // as a full house. 

            if (ThreeOfaKind() && HasPair())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StraightFlush()
        {
            //If both IsFlush and Straight are both true, then 
            // the dealt hand will be recognized as a straight flush.
            if (IsFlush() && Straight())
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public HandType GetRank()
        {
           HandType retval =HandType.HighCard;

            if (RoyalFlush())
            {
                retval =HandType.RoyalFlush;
            }
            else if (FourOfaKind())
            {
                retval =HandType.FourOfaKind;
            }
            else if (FullHouse())
            {
                retval =HandType.FullHouse;
            }
            else if (ThreeOfaKind())
            {
                retval =HandType.ThreeOfaKind;
            }
            else if (StraightFlush())
            {
                retval =HandType.StraightFlush;
            }
            else if (Straight())
            {
                retval =HandType.Straight;
            }
            else if (IsFlush())
            {
                retval =HandType.Flush;
            }
            else if (TwoPair())
            {
                retval =HandType.TwoOfaKind;
            }
            else if (HasPair())
            {
                retval =HandType.Pair;
            }
           return retval;
        }
    }
}

