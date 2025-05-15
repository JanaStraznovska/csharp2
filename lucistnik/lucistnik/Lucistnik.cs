namespace UkolLucisnik
{
    public class Lucistnik
    {
        string _jmeno;
        int _pocetSipu;
        public Lucistnik(string jmeno, int pocetSipu)
        {
            _jmeno = jmeno;
            _pocetSipu = pocetSipu;
        }

        public void Vystrel()
        {
            if (_pocetSipu > 0)
            {
                Console.WriteLine ("Vystrel byl uspesny.");
                _pocetSipu--;
            }
            else
            {
                Console.WriteLine ("Nemas dostatek sipu.");
            }
        }

        public void PrijedSipy(int pocet)
        {
            if (pocet > 0)
            {
                _pocetSipu = _pocetSipu + pocet;
                Console.WriteLine ($"Pocet sipu je {_pocetSipu}");
            }
        }

        public void ZobrazStav()
        {
            Console.WriteLine ($"Aktualni jmeno lucistnika je {_jmeno} a ma {_pocetSipu} sipu.");
        }

    }
}