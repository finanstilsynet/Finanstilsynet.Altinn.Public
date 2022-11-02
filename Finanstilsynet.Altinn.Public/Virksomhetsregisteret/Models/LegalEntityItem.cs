using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("A reference to a legal entity in the registry, including its country.")]
    public record LegalEntityItem : LegalEntityReference
    {
        [Description("The country of residence for the legal entity.")]
        public Country Country { get; init; }

        public LegalEntityItem(long legalEntityId, string legalEntityName, Country country) : base(legalEntityId, legalEntityName)
        {
            Country = country;
        }
    }
}
