using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("Defines an address for a legal entity.")]
    public record Address
    {
        [Description("Defines the address type.")]
        public AddressType Type { get; init; }

        [Description("Detail lines for the address, e.g. house/suite, street name and number, postal code (for most of the non-norwegian addresses)")]
        public string AddressLines { get; init; }

        [Description("The postal code. Mostly used for domestic addresses, but is also supplied for some foreign addresses")]
        public string PostalCode { get; init; }

        [Description("Used for Town/postal names. Will have the official name for norwegian postal codes, for foreign addresses the data is manually added and not validated.")]
        public string PostalLocation { get; init; }

        [Description("Region (\"fylke\") where this postal code is located")]
        public string Region { get; init; }

        [Description("The country for the legal entity. For some legal entities this is the only part of the address we know, and is added to assist in detecting border-crossing activities.")]
        public Country Country { get; init; }
    }
}
