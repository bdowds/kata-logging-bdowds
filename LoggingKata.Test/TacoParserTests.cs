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
            // TODO: Complete Should Parse
            //Arrange

            //Act
            //Assert
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
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
