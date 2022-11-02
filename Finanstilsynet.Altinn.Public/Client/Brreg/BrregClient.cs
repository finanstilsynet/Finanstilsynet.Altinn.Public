#nullable enable
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Altinn.App.Brreg;
using Altinn.App.ConfigOptions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static Altinn.App.Brreg.BrregRoller;


namespace Altinn.App
{
    enum brregResponse { UgyldigOrgNr, OrgIkkeFunnetiBrreg, BrregNede }

    public class BrregClient : IBrregClient
    {
        private static readonly Regex ORGNR_REGEX = new Regex(@"^\d{9}$");
        private static readonly string ORGNR_CACHE_PREFIX = "ORGNR_CACHE_PREFIX";
        private static readonly string ORGNR_CACHE_PREFIX_ROLLER = "ORGNR_CACHE_PREFIX_ROLLER";
        private readonly IMemoryCache _cache;
        private readonly HttpClient _client;
        ILogger<BrregClient> _logger;
        private readonly ApiUrls _apiUrls;



        public BrregClient(IMemoryCache cache, HttpClient client, ILogger<BrregClient> logger, IOptions<ApiUrls> apiUrls)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _apiUrls = apiUrls?.Value ?? throw new ArgumentNullException(nameof(apiUrls));
        }

        public async Task<BrregResponse?> GetBrregResponse(string orgnr)
        {
            if (string.IsNullOrWhiteSpace(orgnr) || !ORGNR_REGEX.IsMatch(orgnr))
            {
                _logger.LogError("Ugyldig orgnummer {orgnummer}", orgnr);
            }

            try
            {
                return await _cache.GetOrCreateAsync(ORGNR_CACHE_PREFIX + orgnr, async (entry) =>
                {
                    var response = await _client.GetAsync(_apiUrls.BrregUrl + orgnr);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError("Innhenting av informasjon feilet med status kode {statusCode}", response.StatusCode);
                    }

                    return await response.Content.ReadAsAsync<BrregResponse>();
                });
            }
            catch (Exception)
            {
                _logger.LogError("Ingen kontakt med Brønnøysundregisteret.");
                throw;
            }
        }

        public async Task<BrregRoller.Root?> GetBrregRollerResponse(string orgnr)
        {
            if (string.IsNullOrEmpty(orgnr) || !ORGNR_REGEX.IsMatch(orgnr))
            {
                _logger.LogError("Ugyldig organisajonsnummer {orgnummer}", orgnr);
            }
            try
            {
                var testRoot = GetTestRoot(orgnr);
                if (testRoot is not null)
                {
                    return testRoot;
                }
                return await _cache.GetOrCreateAsync(ORGNR_CACHE_PREFIX_ROLLER + orgnr, async (entry) =>
                {
                    var response = await _client.GetAsync(_apiUrls.BrregUrl + orgnr + "/roller");
                    var myJsonResponse = await response.Content.ReadAsStringAsync();
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError("Innhenting av informasjon feilet med status kode {statusCode}", response.StatusCode);
                    }
                    return myDeserializedClass;
                });
            }

            catch (Exception)
            {
                _logger.LogError("Ingen response fra Brønnøysundregisteret");
                throw;
            }
        }

        public BrregRoller.Root? GetTestRoot(string orgnr)
        {
            return orgnr switch
            {
                "12345678" => new Root(),
                _ => null,
            };
        }
    }
} 