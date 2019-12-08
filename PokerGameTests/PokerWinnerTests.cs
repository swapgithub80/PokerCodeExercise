using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerGameConsoleApp;
using PokerGameConsoleApp.Common;
namespace PokerGameTests
{
   
    [TestClass]
    public class PokerWinnerTests
    {
        private  string PlayerCards;
      
  
        [TestMethod]
       
        public void TestHighCard()
        {
            PlayerCards = "2C 3H 4S 8C 9D 2H 3D 5S 9C AH";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullHouse()
        {
            PlayerCards = "2S 4S 4C 2D 4H 2H 3D 5S AH 9C";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.LeftHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRoyalFlush()
        {
            PlayerCards = "2S 3S 4S 6S 5S KS JS AS QS TS";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStraight()
        {
            PlayerCards = "2H 3D 5S AH 9C 2C 3S 4D 6H 5C";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void TestStraightFlush()
        {
            PlayerCards = "7H 7D 7C 7S KD 2S 3S 4S 6S 5S";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFlush()
        {
            PlayerCards = "2H 3D 4C 6H 5S 2S 8S AS QS 3S";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPair()
        {
            PlayerCards = "4H 8S 9C KD KH 2C 3H 4D 8C TD";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.LeftHandWins;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFourofaKind()
        {
            PlayerCards = "7H 7D 7C 7S KD 2D 3H 5C 9S 2H";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.LeftHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThreeofaKind()
        {
            PlayerCards = "2H 3D 5S AH 9C 9S KH 7D 7C 7S";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.RightHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTwoPair()
        {
            PlayerCards = "2H 4S 4C 2D KH 2C 3H 4S 8C KD";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.LeftHandWins;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDraw()
        {
            PlayerCards = "2H 3D 5S 9C KD 2D 3H 5C 9S KH";
            var actual = PokerHands.CalculateWinner(PlayerCards);
            var expected = PokerConstants.Draw;
            Assert.AreEqual(expected, actual);
        }
    }
}

