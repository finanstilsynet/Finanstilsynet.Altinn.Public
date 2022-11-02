using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Describes the nature of the service provider's relation to the licence. If 'Licensed', the entity itself is granted the licence. If 'Branch' or 'Agent', the entity operates the licence on behalf of the licence holder as a branch or an agent, respectively.")]
    public enum ServiceProviderType
    {
        Licensed= 0,
        Branch = 1,
        Agent = 2
    }
}
