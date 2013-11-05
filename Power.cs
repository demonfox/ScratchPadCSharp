using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPad
{
    class Power
    {
        public static int totalNumMultiplication = 0;

        public static double Run(double a, int b)
        {
            if (b == 0) return 1;
            if (b == 1) return a;
            double temp = Run(a, b / 2);
            temp = temp * temp;
            if (b % 2 == 0)
            {
                totalNumMultiplication += 1;
                return temp;
            }
            else
            {
                totalNumMultiplication += 2;
                return temp * a;
            }
        }
    }
}
