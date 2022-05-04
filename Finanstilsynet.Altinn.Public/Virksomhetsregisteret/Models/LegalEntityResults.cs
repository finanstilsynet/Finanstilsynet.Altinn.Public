using System.Collections.Generic;
using System.ComponentModel;

namespace Virkreg.Api.Public.Models
{
    [Description("The result of fetching legal entities.")]
    public record LegalEntityResults
    {
        [Description("The number of legal entities in this result.")]
        public int HitsReturned { get; init; }

        [Description("The list of legal entities.")]
        public IEnumerable<LegalEntity> LegalEntities { get; init; }
    }

    [Description("The result of searching for legal entities.")]
    public record PagedLegalEntityResults : LegalEntityResults
    {
        [Description("The page number returned.")]
        public int Page { get; init; }

        [Description("The total number of legal entities that match the query.")]
        public int Total { get; init; }
    }
}
