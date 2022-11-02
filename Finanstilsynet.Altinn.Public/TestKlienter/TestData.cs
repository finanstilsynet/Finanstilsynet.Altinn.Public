namespace Altinn.App.Testklienter
{

    public static class TestData
    {

        public static string OversettTestData(string nr){
            var nyttnr = nr;
                    switch (nr)
                    {
                        case "910054961":
                            nyttnr = "987530707";
                            break;
                        case "810050292":
                            nyttnr = "987547502";
                            break;
                        case "910055364":
                            nyttnr = "987593636";
                            break;
                        case "910078518":
                            nyttnr = "987597046";
                            break;
                        case "910078968":
                            nyttnr = "987634618";
                            break;
                        case "910078836":
                            nyttnr = "987655887";
                            break;   
                    }
                    return nyttnr;
        }

        public static long OversettTestData(long nr){
            var tekst = OversettTestData(nr.ToString());
            return long.Parse(tekst);
            
        }
    }
}