using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
namespace Klädbutiken

{
    class Program
    {
        public static List<string> invetory = new List<string>();
        public static List<string> LiVaru = new List<string>();   // lista varukorg 
        public static int sel=0;

        static void AppenToFile(string ss)
        {
            // öppna filen text av inventory. True indikerar att de nya varor fylls på (Append). 
           // StreamWriter sw = new StreamWriter(@"c:\prova\klädbutiken.txt", true);
            StreamWriter sw = new StreamWriter("klädbutiken.txt", true);
            sw.WriteLine(ss);
            sw.Close();
        }
       
        static void ReadInvetory()  //---NEW
        {
            try    // om filen  "klädbutiken.txt" inte hittats får vi en error system vilket vi hanterar med hjälpen av try-cath. 
            {
                //string vest = File.ReadAllText(@"c:\prova\klädbutiken.txt");
                string vest = File.ReadAllText("klädbutiken.txt");
                string[] riga = vest.Split('\n');

                foreach (string s in riga) if (s.Length > 10) invetory.Add(s);
            }
            catch
            { 
            }  
        }
        
         static string Seleziona2(int sel) 
        {
                
                string pSel = null;      // psell är den utvalda produkten.
                int r = 0;

                foreach (string s in  invetory)
                {
                    Console.SetCursorPosition(40, 3 + r);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (r == sel)         // den utvald produkten skrivs ut rött
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        pSel = s;
                    }
                    Console.Write(s);
                    r++;

                }
                 Console.ForegroundColor = ConsoleColor.White;
                  Console.SetCursorPosition(40, 3 + r++);
                Console.Write("                                      ");    // tar bor sista raden av inventory på console

                return pSel;
        }
        static void skrivaLiVaru(List<string> xx)

        {
            int r = 0, pris = 0;
            foreach (string s in xx)           // läser listan av stränger av varukorgen (xx) 

            {
                Console.SetCursorPosition(80, 4 + r++);
                Console.Write(s);

                try
                {
                    pris += int.Parse(s.Substring(s.Length - 6));
                }

                catch { }
            }
            Console.SetCursorPosition(80, 4 + r++);
            Console.Write($"=====================");
            Console.SetCursorPosition(80, 4 + r++);
            Console.Write($"totalpriset= {pris}");
        }


        static void Main(string[] args)
        {   // skriver ut titlar i en viss ordning på console.

            Console.SetCursorPosition(40, 1);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" K l ä d  b u t i k e n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(80, 2);
            Console.WriteLine("Varukorg");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Inventory");

            ReadInvetory();
            Seleziona2(-1);


            // väljer om att lägga till nya varor.

            do
            {
                //Rengör ("raderar")  delen av skärmen som är relaterad till produkten som vi väljer.
                Console.SetCursorPosition(1, 4);
                for (int i = 0; i < 9; i++) Console.WriteLine("                                    ");
                Console.SetCursorPosition(1, 4);

                Console.Write("Lägg till ny vara  (j/n) ");
                string janej = Console.ReadLine();

                if (janej.ToLower() == "n") break;        //  när vi skriver "n" avslutar loopen.

                kläder kl = new kläder();
                string sfile = kl.LaddaNyProdukt();     // metoden tillhör struktur "kläder".  Det laddar produkterna.
                
                AppenToFile(sfile);       // läggs till i slutet av filen.
               
                 invetory.Add(sfile);
                Seleziona2(-1);

            } while (true);



            //____________ del II______
            
            Seleziona2(-1);    // (-1) visar produkterna i inventory utan att välja ut. 
            Console.SetCursorPosition(1, 16);
            Console.Write("Använd <a> och <z> för att välja.\n <Enter> för att gå till kundvagnen");   // (\n) dvs enter
            int sel = 0;                // sel indikerar index av  den utvalda produkten. ( den som blir röd)
            string produkt="";
            do
            {
                Console.SetCursorPosition(1, 18);
                Console.Write("Lägg till i varukorg? ");

                char ch = Console.ReadKey().KeyChar;   // Readkey().KeyChar, tar in en character "ch".
                if (ch == 'a' && sel > 0) sel--;        // Den utvalda produkten går uppåt
               
                if (ch == 'z') sel++;         // Den utvalda produkten går neråt    

                produkt = Seleziona2(sel);     //  produkt indikerar utvalda produkten i text format 

                if (produkt == null) sel = 0;
                else
                {
                    Console.SetCursorPosition(1, 20);
                    Console.Write("valt objekt {0,-20}", produkt);
                    if (ch == (Char)13)   //KEY=ENTER(13)                    // den utvalda produkten hamnar i varukorgen 
                    {
                        LiVaru.Add(produkt);   //Plaggens ska hamna i en varukorg
                        skrivaLiVaru(LiVaru);  //Varukorg är uppdaterad
                     
                        invetory.Remove(produkt);
                        Seleziona2(-1);
                    }
                }

            } while (invetory.Count>0); // om invetory är tom då avslutar loopen.

            Console.Beep();
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("<< Butiken är tom. Avslutad aktivitet.>>");
            Console.ReadLine();
        }
    }
}