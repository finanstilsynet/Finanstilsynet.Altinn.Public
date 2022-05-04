using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Information about a country.")]
    public record Country
    {
        [Description("The unique three-letter country code, as defined in ISO 3166-1 alpha-3.")]
        public string Iso3 { get; init; }

        [Description("The name of the country.")]
        public TranslatedTerm Name { get; init; }

        public Country(string iso3, string norwegian, string english)
        {
            Iso3 = iso3;
            Name = new TranslatedTerm(norwegian, english);
        }
    }
}
