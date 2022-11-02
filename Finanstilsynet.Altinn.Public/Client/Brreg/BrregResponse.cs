using System;
using System.Net.Http;
using System.Threading.Tasks;
using Altinn.App.Brreg;
using Microsoft.Extensions.Caching;

namespace Altinn.App
{
    public class BrregResponse
    {
        public string Organisasjonsnummer  { get; set; }
        public string Navn { get; set; }
        public Organisasjonsform organisasjonsform { get; set; }

        //TODO: Might add remaining fields from api
    }
}