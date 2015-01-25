using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atomoGrafTezaLicentaGUI
{
    public class algebra//de aceasta clasa posibil sa nu fie nevoie si atunci de-o sters!
    {
        public static long Factorial(long x)
        {
            if (x <= 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }

        public static long Permutation(long n, long r)
        {
            if (r == 0)
                return 0;
            if (n == 0)
                return 0;
            if ((r >= 0) && (r <= n))
                return Factorial(n) / Factorial(n - r);
            else
                return 0;
        }

        public static long Combination(long a, long b)
        {
            if (a <= 1)
                return 1;

            return Factorial(a) / (Factorial(b) * Factorial(a - b));
        }
    }
}
