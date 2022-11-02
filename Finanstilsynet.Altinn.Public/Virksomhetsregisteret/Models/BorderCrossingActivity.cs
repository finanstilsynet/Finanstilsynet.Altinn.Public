using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Virkreg.Api.Public.Models
{
    [Description("Details regarding a border-crossing activity. An activity consists of a provider and a host contry. If the service is provided through a third contry, this transit country is included in the registration.")]
    public record BorderCrossingActivityDetails
    {
        [Description("The host country, i.e. the country in which the service is being provided")]
        public Country HostCountry { get; init; }
        [CanBeNull]
        [Description("If not null: The service provider is located in a third country, different from both the home- and host countries, and the service is being transited through that country.")]
        public Country TransitCountry { get; init; }
        [Description("The legal entity which provides the service in the host country.")]
        public LegalEntityReference ServiceProvider { get; init; }
        [Description("The service provider's relation to the licence.")]
        public ServiceProviderType ServiceProviderType { get; init; }

        // ReSharper disable once RedundantOverriddenMember
        // Because the auto-implemented record ToString is uglier than FluentAssertions' default formatter
        public override string ToString()
        {
            return base.ToString();
        }
    }

    [Description("Information about the border-crossing of a licence service, originating from a home contry, to one or more host countries.")]
    public record BorderCrossingActivity
    {
        [Description("The home country, i.e. the country in which the service originates. Is the same as the country of the licence's supervisory authority.")]
        public Country HomeCountry { get; init; }
        [CanBeNull]
        [Description("The service being border-crossed. The field is null if and only if the licence type does not have a specified set of services. In that case the services are defined implicitly by the licence type, and are border-crossed together.")]
        public LicenceService Service { get; init; }
        [Description("Each item in this list represents a border-crossing of the service to one host country, by one service provider (either the licence holder itself or an agent or branch). Note that the service may be border-crossed to the same country by multiple service providers.")]
        public IEnumerable<BorderCrossingActivityDetails> BorderCrossings { get; init; }
    }
}
