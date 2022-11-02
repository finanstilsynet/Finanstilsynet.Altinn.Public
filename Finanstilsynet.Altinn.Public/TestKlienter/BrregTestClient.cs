
using System;
using System.Threading.Tasks;
using Altinn.App.Brreg;

namespace Altinn.App.Testklienter
{

    public class BrregTestClient : IBrregClient
    {
        private readonly BrregClient _brregClient;

        public BrregTestClient(BrregClient brregClient)
        {
            _brregClient = brregClient ?? throw new ArgumentNullException(nameof(brregClient));
        }

        public async Task<BrregResponse> GetBrregResponse(string orgnr)
        {
            var oversattOrgNr = TestData.OversettTestData(orgnr);

            var retur = await _brregClient.GetBrregResponse(oversattOrgNr);

            if(retur != null){
            retur.Organisasjonsnummer = orgnr;
            }

            return retur;

        }

        public async Task<BrregRoller.Root> GetBrregRollerResponse(string orgnr)
        {
            var oversattOrgNr = TestData.OversettTestData(orgnr);

            var retur = await _brregClient.GetBrregRollerResponse(oversattOrgNr);

            return retur;
        }

    }
}