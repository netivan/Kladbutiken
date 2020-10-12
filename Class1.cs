using System;
using System.Collections.Generic;
using System.Text;

namespace Klädbutiken
{
    struct kläder
    {
        public TYP typ;
        public STORLEK storlek;
        public FÄRG färg;
        public int pris;


        public string LaddaNyProdukt()
        {   // ladda en ny produkt och returnerar strängen med alla info om varan 

            Console.Write("lägga in typ: ");
            typ = (TYP)ivn.readNumber(1, 3);
            Console.Write("lägga in storlek: ");
            storlek = (STORLEK)ivn.readNumber(1, 3);
            Console.Write("lägga in färg: ");
            färg = (FÄRG)ivn.readNumber(1, 3);
            Console.Write("lägga in pris: ");
            pris = ivn.readNumber(0, 100000);

            return string.Format("{0,-7} {1,-2} {2,-6} {3,5}", typ, storlek, färg, pris);
        }
    }



    public enum TYP
    {
        tröja = 1,
        skor = 2,
        byxor = 3
    }

    public enum FÄRG
    {
        röd = 1,
        blå = 2,
        vit = 3
    }

    public enum STORLEK
    {
        s = 1,
        m = 2,
        l = 3
    }

}
