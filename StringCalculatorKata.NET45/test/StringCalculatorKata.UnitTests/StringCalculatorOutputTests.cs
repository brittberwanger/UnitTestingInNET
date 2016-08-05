using Moq;
using NUnit.Framework;

namespace StringCalculatorKata.UnitTests
{
    [TestFixture]
    class StringCalculatorOutputTests
    {
        [Test]
        public void Add_WhenGivenEmptyString_OutputsZero()
        {
            // Arrange (Given)
            var consoleMock = new Mock<IConsole>();
            var stringCalculator = new StringCalculator( consoleMock.Object );

            // Act (When)
            stringCalculator.Add( string.Empty );

            // Assert (Then)
            consoleMock.Verify( console => console.WriteLine( "0" ) );
        }
    }
}
