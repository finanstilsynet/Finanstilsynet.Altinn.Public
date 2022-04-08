using System;

namespace Finanstilsynet.Altinn
{
    public static class Helpers
    {
        public static int Altinn3toAltinn2Language(string language) =>
            language switch
            {
                "nb" => 1044,
                "nn" => 2068,
                "en" => 1033,
                _ => throw new InvalidOperationException($"Unable to convert Altinn3 language code to Altinn2 language. Unknown language {language}")
            };
    }
}
