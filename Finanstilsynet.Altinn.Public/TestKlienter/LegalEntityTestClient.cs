#nullable enable
using System;
using System.Threading.Tasks;
using Altinn.App.Virksomhetsregisteret;


namespace Altinn.App.Testklienter
{

    public class LegalEntityTestClient : ILegalEntityClient
    {
        private readonly LegalEntityClient _client;

        public LegalEntityTestClient(LegalEntityClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public Task<LegalEntityResults?> GetLegalEntityResponse(string? nr)
        {
            var oversattNr = TestData.OversettTestData(nr);
            return _client.GetLegalEntityResponse(oversattNr);
        }
    }
}
