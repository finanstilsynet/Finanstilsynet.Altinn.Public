using Xunit;

namespace Finanstilsynet.Altinn.Tests
{
    public class HelperTests
    {
        [Fact]
        public void Altinn3ToAltinn3Language_ForBokmaal_ReturnsConvertedValue()
        {
            Assert.Equal(1044, Helpers.Altinn3ToAltinn2Language("nb"));
        }
    }
}
