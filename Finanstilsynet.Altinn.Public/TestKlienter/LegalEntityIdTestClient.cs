using System;
using System.Net.Http;
using System.Threading.Tasks;
using Altinn.App.ConfigOptions;
using Altinn.App.Virksomhetsregisteret;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Altinn.App.Testklienter
{

    public class LegalEntityIdTestClient : ILegalEntityIdClient
    {
        private readonly LegalEntityIdClient _client;

        public LegalEntityIdTestClient(LegalEntityIdClient client)
        {
            _client = client?? throw new ArgumentNullException(nameof(client));
        }


        public Task<LegalEntityResults> GetLegalEntityByIdResponse(long nr)
        {
            return _client.GetLegalEntityByIdResponse(nr);
            
        }
    }
}
