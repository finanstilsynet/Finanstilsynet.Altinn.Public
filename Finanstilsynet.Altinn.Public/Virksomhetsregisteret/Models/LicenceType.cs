using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Virkreg.Api.Public.Models
{
    [Description("Information on a licence type.")]
    public record LicenceType
    {
        [Description("The identifier for the licence type.")]
        public string Code { get; init; }

        [Description("The name of the licence type.")]
        public TranslatedTerm Name { get; init; }

        [Description("A short description of the licence, possibly stating the legal framwork under which it is granted.")]
        public TranslatedTerm Description { get; init; }
    }

    [Description("Information on a licence type, including which classifications and services might occur for licences of the type.")]
    public record LicenceTypeDetails : LicenceType
    {
        [Description("If non-empty, instances of the licence type must have one of these classifications.")]
        public IEnumerable<LicenceClassification> PossibleClassifications { get; init; } = Enumerable.Empty<LicenceClassification>();

        [Description("If non-empty, instances of the licence type could be granted one or more of these services.")]
        public IEnumerable<LicenceService> PossibleServices { get; init; } = Enumerable.Empty<LicenceService>();
    }
}
