using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPadCSharp
{
    class LongestCommonSubstring
    {
        public int LCSubstring(string str1, string str2, out string sequence)
        {
            sequence = string.Empty;
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return 0;

            int[,] num = new int[str1.Length, str2.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            StringBuilder sequenceBuilder = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thiSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thiSubsBegin)
                            {
                                sequenceBuilder.Append(str1[i]);
                            }
                            else
                            {
                                lastSubsBegin = thiSubsBegin;
                                sequenceBuilder.Clear();
                                sequenceBuilder.Append(str1.Substring(thiSubsBegin, (i + 1) - thiSubsBegin));
                            }
                        }
                    }
                }
            }
            sequence = sequenceBuilder.ToString();
            return maxlen;
        }
    }
}
