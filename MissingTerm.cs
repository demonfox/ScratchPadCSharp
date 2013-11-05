using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPadCSharp
{
    class MissingTerm
    {
        public static void FindMissingTerm()
        {
            string count = Console.ReadLine();
            string[] input = Console.ReadLine().Split(new char[] { ' ' });
            int[] allNumbers = new int[input.Length];
            for (int i = 0; i < allNumbers.Length; i++)
                allNumbers[i] = Convert.ToInt32(input[i]);
            int diff1 = allNumbers[1] - allNumbers[0];
            int diff2 = Int32.MinValue;

            for (int i = 1; i < allNumbers.Length - 1; i++)
            {
                int diff = allNumbers[i + 1] - allNumbers[i];
                if (diff != diff1)
                {
                    diff2 = diff;

                    if (i == 1)
                    {
                        int diff3 = allNumbers[3] - allNumbers[2];
                        if (diff1 == diff3)
                        {
                            Console.WriteLine(allNumbers[1] + diff1);
                            return;
                        }
                        else
                        {
                            Console.WriteLine(allNumbers[0] + diff2);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine(allNumbers[i] + diff1);
                        return;
                    }
                }
            }
        }
    }
}
