using System;

public static class Gigasecond
{
    public static DateTime Date(DateTime birthDate)
    {
        return birthDate + TimeSpan.FromSeconds(Math.Pow(10, 9));
    }
}