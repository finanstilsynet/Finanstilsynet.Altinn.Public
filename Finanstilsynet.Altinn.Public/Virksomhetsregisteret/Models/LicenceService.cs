using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Information about a service within a licence.")]
    public record LicenceService
    {
        [Description("The service id.")]
        public int ServiceId { get; init; }
        [Description("The name of the service group.")]
        public TranslatedTerm GroupName { get; init; }
        [Description("The name of the service.")]
        public TranslatedTerm ServiceName { get; init; }
    }
}
