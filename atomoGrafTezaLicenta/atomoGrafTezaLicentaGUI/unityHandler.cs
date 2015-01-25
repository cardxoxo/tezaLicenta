using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace atomoGrafTezaLicentaGUI
{
    class unityHandler
    {
        public unityHandler(bool needOnlyKillAllIzographs)
        {
            foreach (var process in Process.GetProcessesByName("izoGraph"))
            {
                process.Kill();
            }

       if (!needOnlyKillAllIzographs)
           try
           {
               Process.Start("izoGraph.exe");
           }
           catch (Exception) { };
        }
    }
}
