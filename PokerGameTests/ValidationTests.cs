using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerGameConsoleApp.Common;

namespace PokerGameTests
{
    [TestClass]
   public class ValidationTests
    {
        private string PlayerCards;
        [TestMethod]
        public void TestCheckNullOrEmpty()
        {
            PlayerCards = "";
            var actualResultException = Assert.ThrowsException<Exception>(() =>CardDataValidations.EvaluatePokerHands(PlayerCards));
            var expectedResult = PokerConstants.InvalidInputMessage;
            Assert.AreEqual(expectedResult, actualResultException.Message);
        }

        [TestMethod]
        public void TestInvalidLenthInput()
        {
            PlayerCards = "2H 3D 5S ";
            var actualResultException = Assert.ThrowsException<Exception>(() => CardDataValidations.EvaluatePokerHands(PlayerCards));
            var expectedResult = PokerConstants.InvalidInputLengthMessage;
            Assert.AreEqual(expectedResult, actualResultException.Message);
        }

        [TestMethod]
        public void TestInvalidCardSuit()
        {
            PlayerCards = "2H 3D 5S 9C KX 2C 3Z 4S 8C AH";
            var actualResultException = Assert.ThrowsException<Exception>(() => CardDataValidations.EvaluatePokerHands(PlayerCards));
            var expectedResult = PokerConstants.InvalidInputSuitsMessage;
            Assert.AreEqual(expectedResult, actualResultException.Message);
        }

        [TestMethod]
        public void TestInvalidCardRank()
        {
            PlayerCards = "1H 3D 1S 9C KH 2C 3S 1D 8C AH";
            var actualResultException = Assert.ThrowsException<Exception>(() => CardDataValidations.EvaluatePokerHands(PlayerCards));
            var expectedResult = PokerConstants.InvalidInputRanksMessage;
            Assert.AreEqual(expectedResult, actualResultException.Message);
        }

        [TestMethod]
        public void TestHasDuplicateCards()
        {
            PlayerCards = "2H 3D 5S 9C 9C 2C 3Z 4S 8C AH";
            var actualResultException = Assert.ThrowsException<Exception>(() => CardDataValidations.EvaluatePokerHands(PlayerCards));
            var expectedResult = PokerConstants.InvalidInputDuplicatesMessage;
            Assert.AreEqual(expectedResult, actualResultException.Message);
        }

    }
}
