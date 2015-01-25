using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicentaGUI
{
    public struct dateGraf
    {
        public string atomi;
        public int[][] matr;
    }

    class graphWorker
    {
        public graphWorker(dateGraf date)
        {

            new fileWriter(date);

        }
    }
}
