using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("A fixed term with translation")]
    public record TranslatedTerm
    {
        [Description("Norwegian translation")]
        public string Norwegian { get; }
        [Description("English translation")]
        public string English { get; }

        public TranslatedTerm(string norwegian, string english)
        {
            Norwegian = norwegian;
            English = english;
        }
    }
}
