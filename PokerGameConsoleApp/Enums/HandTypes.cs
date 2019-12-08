using System;
using System.ComponentModel;


namespace PokerGameConsoleApp.Enums
{
    public enum HandType
    {
        [Description("Royal Flush")]
        RoyalFlush,
        [Description("Straight flush")]
        StraightFlush,
        [Description("Fourofakind")]
        FourOfaKind,
        [Description("Fullhouse")]
        FullHouse,
        [Description("Flush")]
        Flush,
        [Description("Straight")]
        Straight,
        [Description("Three of a kind")]
        ThreeOfaKind,
        [Description("Two pair")]
        TwoOfaKind,
        [Description("One pair")]
        Pair,
        [Description("High Card")]
        HighCard
    }
}
