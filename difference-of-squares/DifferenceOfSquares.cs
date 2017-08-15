using System;
using System.Linq;

public static class Squares
{
    public static int SquareOfSums(int max)
    {
        return (int)Math.Pow(Enumerable.Range(1, max).Sum(i => i), 2);
    }

    public static int SumOfSquares(int max)
    {
        return (int)Enumerable.Range(1, max).Sum(i => Math.Pow(i, 2));
    }

    public static int DifferenceOfSquares(int max)
    {
        return SquareOfSums(max) - SumOfSquares(max);
    }
}