using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Virkreg.Api.Public.Models
{

    [Description("Information about a licence. The licence can either be granted directly to an entity, or it can be used by a branch or an agent of a licence holder.")]
    public record Licence
    {
        [Description("The legal entity granted the licences.")]
        public LegalEntityReference LicensedEntity { get; init; }

        [Description("The legal entity providing the service. This can be a different entity than the licensed entity.")]
        public long ServiceProviderId { get; init; }

        [Description("The type of licence.")]
        public LicenceType LicenceType { get; init; }

        [CanBeNull]
        [Description("Any subclassification of the licence, if applicable.")]
        public LicenceClassification LicenceClassification { get; init; }

        [Description("The legal authority granting and regulating this licence.")]
        public LegalEntityItem SupervisoryAuthority { get; init; }

        [CanBeNull]
        [Description("Status for any required financial security for this licence.")]
        public bool? HasSecurity { get; init; }

        [Description("The registration date of this licence.")]
        public DateTime RegisteredDate { get; init; }

        [Description("The relation this service provider has to the licence.")]
        public ServiceProviderType ServiceProviderType { get; init; }

        [CanBeNull]
        [Description("Any relevant remarks to the granted licence")]
        public TranslatedTerm Remarks { get; init; }

        [Description("Lists any services granted within this licence. Only populated if Finanstilsynet is the supervisory authority for this licence.")]
        public IEnumerable<LicenceService> Services { get; init; }

        [Description("Lists any border-crossing activity related to Norway registered on this licence.")]
        public IEnumerable<BorderCrossingActivity> BorderCrossingActivity { get; init; }

        [Description("Any cooperation groups for the licence. Applicable to auditors and auditor companies.")]
        public IEnumerable<CooperationGroup> CooperationGroups { get; init; }

        [Description("A list of roles related to the licence, in context of the current service provider.")]
        public IEnumerable<RelationType> Roles { get; init; }

        [Description("A list of agents or branches using the granted licence. Only applies when the ServiceProviderType is 'Licensed'.")]
        public IEnumerable<AgentOrBranch> AgentsOrBranches { get; init; }

        [Description("A list of auditors connected to this auditor company. Applies to auditor licences only.")]
        public IEnumerable<LegalEntityReference> AccreditedAuditors { get; init; }

        [Description("A list of legal entities for which the service provider provides audits.")]
        public IEnumerable<LegalEntityReference> AuditorFor { get; init; }
    }

    [Description("The possible types of cooperation group URIs.")]
    public enum CooperationGroupType
    {
        Email = 0,
        Url = 1,
    }
}
