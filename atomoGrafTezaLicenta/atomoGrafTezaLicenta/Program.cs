using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicenta
{
    
    //deci, pina cind, date de intrare - un set de atomi, date de iesire, toti izomerii posibili de compus cu atomii astia
    //pentru moment, incercam numa cu 3 variante de atomi - C, H, O

    public class izomer
    {
        int[,] matriceDeAdiacenta;

        
    }

    public class Program
    {
        public static int  nrDeAtomi;
        public static string[] atomi;//nu char caci unii atomi din tablita lu mendeleev is scrisi cu 2 litere - Zn, Na, etc.

        static void Main(string[] args)
        {
                                                            //crearea masivului pt atomi:
            Console.WriteLine("da-ti numarul de atomi:");
            nrDeAtomi = Convert.ToInt32(Console.ReadLine());
            atomi = new string[nrDeAtomi];

            Console.WriteLine("da-ti simbolurile atomilor: (ca in tablita lui Mendeleev)");

        }
    }
}
