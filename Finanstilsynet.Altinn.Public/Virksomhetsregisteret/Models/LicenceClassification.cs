using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Information about the classifications for a licence type. Each licence can have zero or one classification at any given time. Classifications are used solely for Auditor-licences.")]
    public record LicenceClassification
    {
        [Description("The identifier for the classification type.")]
        public int LicenceClassificationId { get; init; }
        [Description("An alphanumerical code for the classification.")]
        public string Code { get; init; }
        [Description("A short description of the classification")]
        public TranslatedTerm Name { get; init; }
    }
}
