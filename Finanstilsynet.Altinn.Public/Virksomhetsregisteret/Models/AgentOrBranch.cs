using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Reference to a legal entity in the registry, including country and the service provider type (i.e. Agent or Branch).")]
    public record AgentOrBranch : LegalEntityItem
    {
        [Description("Service provider type")]
        public ServiceProviderType ServiceProviderType { get; }

        public AgentOrBranch(long legalEntityId, string legalEntityName, Country country, ServiceProviderType serviceProviderType)
            : base(legalEntityId, legalEntityName, country)
        {
            ServiceProviderType = serviceProviderType;
        }
    }
}
