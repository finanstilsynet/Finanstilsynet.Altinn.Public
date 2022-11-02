using System.Collections.Generic;
using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("A group of legal entities that all have the same relation to the current legal entity.")]
    public record RelationType
    {
        [Description("A description of the relation type.")]
        public TranslatedTerm Description { get; init; }

        [Description("A list of legal entities having the same relation type.")]
        public IEnumerable<LegalEntityItem> RelatedEntities { get; init; }
    }
}
