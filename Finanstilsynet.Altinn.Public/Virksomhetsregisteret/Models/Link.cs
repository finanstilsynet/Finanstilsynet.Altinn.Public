using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("An external reference related to a licence. Used for references to \"Forsikringsagentregisteret\" or \"Finansagentregisteret\".")]
    public record Link
    {
        [Description("A header/title describing what the Url is pointing to")]
        public TranslatedTerm Title { get; init; }
        [Description("The actual URL to the english reference site.")]
        public string EnglishUrl { get; init; }
        [Description("The actual URL to the norwegian reference site.")]
        public string NorwegianUrl { get; init; }

    }
}
