using NUnit.Framework;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldReturnNullForNullOrEmptyString()
        {
            var empty = "";
            string nul = null;
            var parser = new TacoParser();

            var emptyResult = parser.Parse(empty);
            var nullResult = parser.Parse(nul);

            Assert.IsNull(emptyResult, "Should return null for empty strings");
            Assert.IsNull(nullResult, "Should return null for null strings");
        }

        [Test]
        public void ShouldReturnNullForNoLatAndLon()
        {
            var line = "-83.2342, Testing";
            var parser = new TacoParser();

            var result = parser.Parse(line);

            Assert.IsNull(result, "Should return null unless we have both the lat and lon");
        }

        [Test]
        public void ShouldParseString()
        {
            const string line =
                "-84.677017, 34.073638, \"Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)";
            var parser = new TacoParser();

            var result = parser.Parse(line);

            Assert.IsNotNull(result);
        }
    }
}