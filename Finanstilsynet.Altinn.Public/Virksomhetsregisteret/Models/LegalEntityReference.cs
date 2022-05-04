using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("A reference to a legal entity in the registry.")]
    public record LegalEntityReference
    {
        [Description("The entity identifier for the legal entity.")]
        public long LegalEntityId { get; }

        [Description("The natural name or company name")]
        public string LegalEntityName { get; }

        public LegalEntityReference(long legalEntityId, string legalEntityName)
        {
            LegalEntityId = legalEntityId;
            LegalEntityName = legalEntityName;
        }
    }
}
