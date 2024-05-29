 using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.635282, -86.684056, Taco Bell Birmingham...", -86.684056)]
        [InlineData("32.364153,-86.269979,Taco Bell Montgomery...",-86.269979)]
        [InlineData("30.669595,-87.851786,Taco Bell Spanish For...", -87.851786)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line).Location.Longitude;
            
            Assert.Equal(expected, actual);
            //Arrange

            //Act

            //Assert
        }

        [Theory]
        [InlineData("32.465342,-84.919767,Taco Bell Columbus...", 32.465342)]
        [InlineData("34.796417,-84.962282,Taco Bell Dalton...", 34.796417)]
        [InlineData("33.283584,-86.855317,Taco Bell Helena...", 33.283584)]
        [InlineData("33.635282, -86.684056, Taco Bell Birmingham...", 33.635282)]
        [InlineData("30.669595,-87.851786,Taco Bell Spanish For...", 30.669595)]

        public void ShouldParseLatitude(string line,double expected)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }

        //TODO: Create a test called ShouldParseLatitude

    }
}
