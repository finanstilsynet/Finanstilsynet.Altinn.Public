using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Information about the relation a legal entity has to another entity.")]
    public record EntityRelation
    {
        [Description("The nature of the relation.")]
        public TranslatedTerm RelationType { get; init; }
        [Description("A link to the related legal entity.")]
        public LegalEntityItem LegalEntityItem { get; init; }
    }
}
