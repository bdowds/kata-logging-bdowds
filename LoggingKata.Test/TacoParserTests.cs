using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("-84.677017, 34.073638,\"Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)\"")]
        [InlineData("-84.677017, 34.073638")]
        public void ShouldParse(string str)
        {
            //Arrange
            var testParser = new TacoParser();
            //Act
            var result = testParser.Parse(str);
            //Assert
            Assert.NotNull(result);
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
            //Arrange
            var testParser = new TacoParser();
            //Act
            var result = testParser.Parse(str);
            //Assert
            Assert.Null(result);
        }
    }
}
