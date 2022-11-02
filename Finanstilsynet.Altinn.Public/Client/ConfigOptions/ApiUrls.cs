using System.ComponentModel.DataAnnotations;

namespace Altinn.App.ConfigOptions
{
    public class ApiUrls
    {
        [Url]
        [Required]
        public string BrregUrl { get; set; } = default;

        [Url]
        [Required]
        public string LegalEntityUrl { get; set; } = default;

        [Url]
        [Required]
        public string LegalEntityIdUrl { get; set; } = default;

        [Url]
        [Required]
        public string OppdragsansvarligRevisorUrl { get; set; } = default;

    }
}
