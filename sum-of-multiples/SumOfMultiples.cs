using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int To(IEnumerable<int> multiples, int max)
    {
        var sum = 0;
        for (var i = 1; i < max; i++)
        {
            if (multiples.Any(m => i % m == 0))
            {
                sum += i;
            }
        }
        return sum;
    }
}