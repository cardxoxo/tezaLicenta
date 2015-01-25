using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicentaGUI
{
    public static partial class izomeri//partial pentru ca sa o pot face nested pe izomer pentru izomeri
    {                                  //dar totodata sa fie inafara codului de baza a izomeri
        public class izomer             //am vrut sa o fac nested ca sa pot accesa membrii privati
        {                               //in special vectorul de izomeri
            int nrDeAtomi;
            int[,] matriceDeAdiacenta;//este o idee de a transforma matricea de adiacenta din int in bool

            public izomer()
            {
                nrDeAtomi = atomi.getVectorDeAtomi().Length;
                matriceDeAdiacenta = new int[nrDeAtomi, nrDeAtomi];
            }

            public int[,] getMatrice()
            {
                return matriceDeAdiacenta;
            }

            public void setMatrice(int[,] sent)
            {
                matriceDeAdiacenta = sent;
            }

        }
    }

    public static partial class izomeri
    {
        static long nrDeIzomeri;
        static List<izomer> vectorIzomeri;
        static long nrDeLegaturiInIzomer;

        static void inscriereDateInFisier()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("izomeri.txt");

            atom[] atomList = atomi.getVectorDeAtomi();

            for (int i = 0; i < atomList.Length; i++)
            {
                                file.WriteLine(atomList[i].getNume());
                                file.WriteLine(atomList[i].getRaza());
                                file.WriteLine(atomList[i].getValenta());
                                
            }
            file.WriteLine("$$$$$");
            int[,] temp;
            for (int i = 0; i < nrDeIzomeri; i++)
            {
                temp = vectorIzomeri[i].getMatrice();

                for (int j = 0; j < atomList.Length; j++)
                {
                    file.WriteLine();
                    for (int k = 0; k < atomList.Length; k++)
                        file.Write(temp[j, k]);
                }
                file.WriteLine("\n");
            }

                file.Close();
        }

        public static bool generareIzomeri()
        {
            //intrebare - citi izomeri
            //constringeri: fara legaturi multiple
                               //fara cicluri
                               //valentele - numai egale cu gradul de oxidare
                               //pot fi dati atomii numai pentru scheletul compusului, hidrogenii se adauga automat
                               //fara izomerie optica, adica levorotatory si dextrorotatory izomeri vor fi ca unul si acelasi

                if (atomi.getVectorDeAtomi().LongLength < 1) return false;  //in caz ca nu avem atomi
                nrDeLegaturiInIzomer = atomi.getVectorDeAtomi().LongLength-1;   
                vectorIzomeri = new List<izomer>();
                vectorIzomeri.Add(new izomer());
                int[,] temp = vectorIzomeri.Last().getMatrice();

                if (nrDeLegaturiInIzomer==0) //in caz ca avem numai un atom
                {
                    vectorIzomeri.Last().setMatrice(temp);
                     vectorIzomeri.Add(new izomer());
                        vectorIzomeri.Last().setMatrice(null);
                    
                } else

            if (nrDeLegaturiInIzomer==1) //in caz ca avem numai 2 atomi
            {
                temp[1,0]=1;//DA PRECIS NU TEMP[0,1]???
                vectorIzomeri.Last().setMatrice(temp);
                     vectorIzomeri.Add(new izomer());
                        vectorIzomeri.Last().setMatrice(null);
                    
            } else
            {

                for (int i = 0; i < nrDeLegaturiInIzomer; i++) temp[i + 1, i] = 1;

                vectorIzomeri.Last().setMatrice(temp);

             
                    do
                    {
                      //  for x=1; x<nrDeLegaturiInIzomer; x++)
                        //    for y=

                        vectorIzomeri.Add(new izomer());

                        vectorIzomeri.Last().setMatrice(null);
                    }
                    while (vectorIzomeri.Last().getMatrice() != null);
              
                
                    }
                nrDeIzomeri = vectorIzomeri.Count() - 1; //caci ultimul e ala cu matricea nula
                inscriereDateInFisier();
           return true;
            
                 
        }
    }
}
