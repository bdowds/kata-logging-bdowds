using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("Example")]
        public void ShouldParse(string str)
        {
            //Arrange
            var testParser = new TacoParser();
            //Act
            var result = testParser.Parse(str);
            //Assert
            Assert.Equal(null, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Not a number, Same")]
        [InlineData("-86.841402")]
        [InlineData("-181, 0")]
        [InlineData("181, 0")]
        [InlineData("0, 91")]
        [InlineData("0, -91")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            var testParser = new TacoParser();
            //Act
            var result = testParser.Parse(str);
            //Assert
            Assert.Equal(null, result);
        }
    }
}
