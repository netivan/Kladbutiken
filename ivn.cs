using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Klädbutiken
{
    class ivn
    {
        public static void msgError() 
        {
            Console.Beep();
            Console.Write("Wrong!");
        }

        public static int readNumber(int min , int max)
        {
            
            int num = 0;
            bool error;
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;

            do
            {
                error = false;

                Console.SetCursorPosition(origCol, origRow);
                string s = Console.ReadLine();

                try
                {
                    num = int.Parse(s);
                }
                catch
                {
                    error = true;
                }

                if (num < min || num > max) 
                    error = true;

                if (error == true)

                    msgError();
                    

            } while (error); 

            return num;
        } 

    }
}
