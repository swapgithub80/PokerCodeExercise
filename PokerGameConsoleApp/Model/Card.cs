using PokerGameConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameConsoleApp.Model
{
    public class Card
    {
        public int Rank { get; set; }
        public string Suit { get; set; }

        public Card(string cardString)
        {

            string tempRank = cardString[0].ToString();
            switch (tempRank)
            {
                case "T":
                    this.Rank = Convert.ToInt16(Ranks.Ten);
                    break;
                case "J":
                    this.Rank = Convert.ToInt16(Ranks.Jack);
                    break;
                case "Q":
                    this.Rank = Convert.ToInt16(Ranks.Queen);
                    break;
                case "K":
                    this.Rank = Convert.ToInt16(Ranks.King);
                    break;
                case "A":
                    this.Rank = Convert.ToInt16(Ranks.Ace);
                    break;
                default:

                    this.Rank = int.Parse(tempRank);
                    break;
            }
            this.Suit = cardString[1].ToString();
        }
    }
}


