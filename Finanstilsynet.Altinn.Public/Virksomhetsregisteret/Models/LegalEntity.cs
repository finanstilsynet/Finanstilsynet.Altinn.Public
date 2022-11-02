using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;

namespace Virkreg.Api.Public.Models
{
    [Description("Contains all the information available about a legal entity.")]
    public record LegalEntity
    {
        [Description("An entity identifier for the legal entity")]
        public long LegalEntityId { get; init; }

        [CanBeNull]
        [Description("The entity identifier refering to the parent/main company of the legal entity (if any).")]
        public long? ParentId { get; init; }

        [Description("The type of entity.")]
        public LegalEntityType LegalEntityType { get; init; }

        [Description("Finanstilsynet provides an identifier for all companies and persons that are in the registry. The identifier has the format of `FT00000000'.")]
        public string FinanstilsynetId { get; init; }

        [CanBeNull]
        [Description("The organisation number of the entity. Applies to Norwegian (registered) companies only.")]
        public string OrganisationNumber { get; init; }

        [CanBeNull]
        [Description("Applies to Auditor-licencees only. This is the official auditor number assigned when the auditor becomes a registered auditor.")]
        public string AuditorNumber { get; init; }

        [Description("The natural name of a person, or the company name.")]
        public string Name { get; init; }

        [Description("A list of all active licences under which the legal entity can provide services.")]
        public IEnumerable<Licence> Licences { get; init; }

        [Description("The registered addresses for the entity")]
        public IEnumerable<Address> Addresses { get; init; }

        [Description("A list of links/URLs to the company.")]
        public IEnumerable<Link> Links { get; init; }

        [Description("A list of relations this entity has with other companies.")]
        public IEnumerable<EntityRelation> RelationsToOther { get; init; }

        [Description("A list of participants of this company. Mostly used for Auditor/accountant-licencees.")]
        public IEnumerable<LegalEntityReference> Participants { get; init; }

        [Description("A list of companies this entity participates in. Mostly used for Auditor/accountant-licencees.")]
        public IEnumerable<LegalEntityReference> ParticipatesIn { get; init; }

        [Description("Any additional information about the legal entity")]
        public TranslatedTerm Remarks { get; init; }
    }
}
