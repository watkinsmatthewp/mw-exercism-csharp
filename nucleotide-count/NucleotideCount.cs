using System;
using System.Collections.Generic;

public class DNA
{
    public IDictionary<char, int> NucleotideCounts { get; private set; } = new Dictionary<char, int>
    {
        ['A'] = 0,
        ['T'] = 0,
        ['C'] = 0,
        ['G'] = 0
    };
    
    public DNA(string sequence)
    {
        foreach (var c in sequence)
        {
            NucleotideCounts[c]++;
        }
    }

    public int Count(char nucleotide)
    {
        if (!NucleotideCounts.ContainsKey(nucleotide))
        {
            throw new InvalidNucleotideException();
        }
        return NucleotideCounts[nucleotide];
    }
}

public class InvalidNucleotideException : Exception { }
