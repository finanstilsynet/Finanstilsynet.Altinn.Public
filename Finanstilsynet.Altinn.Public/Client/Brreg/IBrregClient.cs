#nullable enable
using System.Threading.Tasks;
using Altinn.App.Brreg;


namespace Altinn.App
{
    public interface IBrregClient
    {
        Task<BrregResponse?> GetBrregResponse(string orgnr);
        Task<BrregRoller.Root?> GetBrregRollerResponse(string orgnr);
    }
} 