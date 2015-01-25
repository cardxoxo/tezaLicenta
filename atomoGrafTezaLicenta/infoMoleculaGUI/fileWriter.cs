using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicentaGUI
{
    class fileWriter
    {
        public fileWriter(dateGraf date)
        {
            int nrDeAtomi = date.atomi.Length / 3;
            System.IO.StreamWriter file = new System.IO.StreamWriter("molecule.txt");
            file.WriteLine(date.atomi);
            for (int i = 0; i < nrDeAtomi; i++)
            {
                file.WriteLine();
                for (int j = 0; j < nrDeAtomi; j++)
                    file.Write(date.matr[i][j]);
            }
            file.Close();
        }
    }
}
