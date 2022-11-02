using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("A categorisation of legal entities as either a company or person.")]
    public enum LegalEntityType
    {
        Company = 1,
        Person = 2
    }
}
