using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public static class colorParsing
    {
        public static Color parser(string col)
        {

            string[] strings = col.Split(',');

            Color output = new Color();
            for (int i = 0; i < 4; i++)
                output[i] = System.Single.Parse(strings[i]);

            return output;

        }
    }
}
