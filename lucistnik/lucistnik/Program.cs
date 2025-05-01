namespace UkolLucisnik;

class Program
{
    static void Main(string[] args)
    {
        Lucistnik Pepa = new Lucistnik("Pepa", 6);

        while (true)
        {
            Pepa.ZobrazStav();
            Console.WriteLine("1. Vystrelit sip");
            Console.WriteLine("2. Pridat sipy");
            Console.WriteLine("3. Konec");

            string hodnotaCoZadalUzivatel = Console.ReadLine();
            int coMaLucistnikDelat;
            bool spravnaHodnota = int.TryParse(hodnotaCoZadalUzivatel, out coMaLucistnikDelat);

            if (spravnaHodnota == false)
            {
                Console.WriteLine($"Nezadal jsi cislo, zadej hodnotu znovu.");
            }
            else
            {
                switch (coMaLucistnikDelat)
                {
                    case 1:
                        Pepa.Vystrel();
                        break;
                    case 2:
                        int pocetPridavanychSipu = NactiPrirozeneCisloZKonzole("Zadej pocet sipu");

                        Pepa.PrijedSipy(pocetPridavanychSipu);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Nezadal jsi platnou volbu.");
                        break;
                }
            }
        }
    }

    public static int NactiPrirozeneCisloZKonzole(string vyzva)
    {
        while (true)
        {
            Console.WriteLine(vyzva);
            string zadanaHodnotaOdUzivatele = Console.ReadLine();
            int zadaneCisloOdUzivatele = 0;

            bool jeToCislo = int.TryParse(zadanaHodnotaOdUzivatele, out zadaneCisloOdUzivatele);

            if (jeToCislo && (zadaneCisloOdUzivatele > 0))
            {
                return zadaneCisloOdUzivatele;
            }
        }
    }
}
