using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Hamming
{
    /// <summary>
    /// Counts the number of character-position differences betwee two strings (assumed ot be of equal length)
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static int Compute(string p1, string p2)
    {
        int differenceCount = 0;
        for (int i = 0; i < p1.Length; i++)
        {
            if (p1[i] != p2[i])
            {
                differenceCount++;
            }
        }
        return differenceCount;
    }
}