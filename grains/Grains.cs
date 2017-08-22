using System;
using System.Linq;

public static class Grains
{
    private const int SQUARES_IN_BOARD = 64;
    
    public static ulong Square(int n) => (ulong)Math.Pow(2, n-1);

    public static ulong Total() => (ulong)Math.Pow(2, SQUARES_IN_BOARD) - 1;
}