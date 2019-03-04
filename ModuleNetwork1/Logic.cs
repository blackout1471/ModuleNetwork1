using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleNetwork1
{
    class Logic
    {
        public static string FormatString(string[,] input)
        {
            StringBuilder output = new StringBuilder();
            int[] maxChars = new int[input.GetLength(1)];
            for (int i = 0; i < maxChars.Length; i++)
            {
                maxChars[i] = GetMaxColumnWidth(input, i);
            }
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    output.Append(input[i, j].PadLeft(maxChars[j]));
                    if (j != input.GetLength(1)-1)
                    {
                        output.Append("|");
                    }
                }
                output.Append("\n");
            }
            return output.ToString();
        }

        public static int GetMaxColumnWidth(string[,] input, int column)
        {
            int max = 0;
            for (int i = 0; i < input.GetLength(0); i++)
            {
                if (input[i,column].Length > max)
                {
                    max = input[i,column].Length;
                }
            }
            return max;
        }
    }
}
