using System;
using System.Collections.Generic;
using System.Linq;

public class Allergies
{
    private static readonly Dictionary<string, int> ALL_ALERGIES = new Dictionary<string, int>
    {
        ["eggs"] = 1,
        ["peanuts"] = 2,
        ["shellfish"] = 4,
        ["strawberries"] = 8,
        ["tomatoes"] = 16,
        ["chocolate"] = 32, // Poor thing
        ["pollen"] = 64,
        ["cats"] = 128
    };

    private int _mask;
    
    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(string allergy)
    {
        return (_mask & ALL_ALERGIES[allergy]) != 0;
    }

    public IList<string> List()
    {
        return ALL_ALERGIES.Keys.Where(k => IsAllergicTo(k)).ToArray();
    }
}