using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicentaGUI
{
    public class atom
    {
       public atom(char tip)
        {
            switch (tip)
            {
                case 'C': nume = "carbon";   valenta = 4; raza = 91; break;//raza - picometri!
                case 'N': nume = "azot";     valenta = 4; raza = 92; break;
                case 'O': nume = "oxigen";   valenta = 2; raza = 60; break;
            }
        }

        string nume;
        int valenta;
        float  raza;
         

        public    int getValenta() { return valenta; }
        public  float    getRaza() { return raza; }
        public string    getNume() { return nume; }
    }

    public static class atomi
    {
        public static Form1 handleForma;

        static string atomiCurenti;

        static int  nrDeAtomi;
        static atom[] vectorAtomi;//nu char caci unii atomi din tablita lu mendeleev is scrisi cu 2 litere - Zn, Na, etc.

        static int nrDeHidrogeni;

                                                                                                                                     /*   public static int retNrDeAtomi()//metoda asta a fost scrisa sub travka asa ca posibil o sa trebuiasca de-o sters.
                                                                                                                                        {
                                                                                                                                            return nrDeAtomi;
                                                                                                                                        }*/

        public static string getAtomiCurenti()
        {
            return atomiCurenti;
        }

        public static void zeroNrAtomi()
        {
            nrDeAtomi = 0;
            nrDeHidrogeni = 0;
        }

        public static void incrNrAtomi()
        {
            nrDeAtomi++;
        }

        public static void decrNrAtomi()
        {
            nrDeAtomi--;
        }

        static atomi()
        {
            nrDeAtomi = 0;
        }

        public static void creareVectorAtomi(string stringAtomi)
        {
            atomiCurenti = stringAtomi;
            nrDeHidrogeni = 0;

            vectorAtomi = new atom[nrDeAtomi];
            for (int i = 0; i<nrDeAtomi; i++) vectorAtomi[i] = new atom(Convert.ToChar(stringAtomi.Substring(i*3, 1)));

            switch(nrDeAtomi)
            {
                case 0: break;
                case 1: 
                nrDeHidrogeni = vectorAtomi[0].getValenta();     break;
                case 2:
                for (int i = 0; i < nrDeAtomi; i++)
                nrDeHidrogeni += vectorAtomi[i].getValenta()-1;  break;
                default:
                for (int i = 0; i < nrDeAtomi; i++)
                nrDeHidrogeni += vectorAtomi[i].getValenta()-1;
                nrDeHidrogeni--;                                 break;
               
            }
            handleForma.completeazaCuHidrogen(nrDeHidrogeni); 
        }

        public static atom[] getVectorDeAtomi()
        {
            return vectorAtomi;
        }

    }
}
