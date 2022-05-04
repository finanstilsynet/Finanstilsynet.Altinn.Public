using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("References/link to the cooperation group.")]
    public record CooperationGroup
    {
        [Description("The type of references")]
        public CooperationGroupType Id { get; init; }
        [Description("The URI for the cooperation group.")]
        public string Uri { get; init; }
    }
}
