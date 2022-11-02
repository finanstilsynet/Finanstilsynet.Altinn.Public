using System.Collections.Generic;

namespace Altinn.App.Brreg
{
    public class BrregRoller
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class Root
        {
            public List<Rollegrupper> rollegrupper { get; set; }
            public Links _links { get; set; }
        }
        public class Enhet
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Enhet enhet { get; set; }
        }

        public class Navn
        {
            public string fornavn { get; set; }
            public string mellomnavn { get; set; }
            public string etternavn { get; set; }
        }

        public class Person
        {
            public string fodselsdato { get; set; }
            public Navn navn { get; set; }
            public bool erDoed { get; set; }
        }

        public class Rollegrupper
        {
            public Type type { get; set; }
            public string sistEndret { get; set; }
            public List<Roller> roller { get; set; }
        }

        public class Roller
        {
            public Type type { get; set; }
            public Person person { get; set; }
            public ValgtAv valgtAv { get; set; }
            public bool fratraadt { get; set; }
            public int rekkefolge { get; set; }
        }

        public class Self
        {
            public string href { get; set; }
        }

        public class Type
        {
            public string kode { get; set; }
            public string beskrivelse { get; set; }
            public Links _links { get; set; }
        }

        public class ValgtAv
        {
            public string kode { get; set; }
            public string beskrivelse { get; set; }
            public Links _links { get; set; }
        }


    }
}
