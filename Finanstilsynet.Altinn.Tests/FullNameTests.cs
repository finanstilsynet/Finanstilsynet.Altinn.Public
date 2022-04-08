using Xunit;
using Finanstilsynet.Altinn;

namespace Finanstilsynet.Altinn.Tests
{
    public class FullNameTests
    {
        [Theory]
        [InlineData(" a ", null, null, "a")]
        [InlineData(null, " b ", null, "b")]
        [InlineData(null, null, " c ", "c")]
        [InlineData(" a ", " b ", null, "a b")]
        [InlineData(" a ", null, " c ", "a c")]
        [InlineData(null, " b ", " c ", "b c")]
        [InlineData(" a ", " b ", " c ", "a b c")]
        [InlineData(null, null, null, "")]
        [InlineData("  ", "  ", "  ", "")]
        public void FullName(string first, string middle, string last, string expected)
        {
            var actual = Finanstilsynet.Altinn.FullName.Concat(first, middle, last);
            Assert.Equal(expected, actual);
        }
    }
}
