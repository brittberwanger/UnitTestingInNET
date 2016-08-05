using System;
using NUnit.Framework;

namespace StringCalculatorKata.UnitTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_WhenGivenEmptyString_ReturnsZero()
        {
            arrangeActAndAssertExpectedEqualsActual(default(string), 0);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("200", 200)]
        public void Add_WhenGivenSingleNumber_ReturnsThatNumber(string value, int expectedResult)
        {
            arrangeActAndAssertExpectedEqualsActual(value, expectedResult);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        public void Add_WhenGivenCommaDelimitedNumbers_ReturnsTheSumOfThoseNumbers(string value, int expectedResult)
        {
            arrangeActAndAssertExpectedEqualsActual(value, expectedResult);
        }

        [Test]
        public void Add_WhenGivenNegativeNumber_ThrowsException()
        {
            // Arrange (Given)
            var stringCalculator = new StringCalculator();

            // Act (When)
            TestDelegate testDelegate = delegate { stringCalculator.Add("-1, 2"); };

            // Assert (Then)
            Assert.Throws<Exception>(testDelegate);
        }

        private static void arrangeActAndAssertExpectedEqualsActual(string value, int expectedResult)
        {
            // Arrange (Given)
            var stringCalculator = new StringCalculator();

            // Act (When)
            int actualResult = stringCalculator.Add(value);

            // Assert (Then)
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
