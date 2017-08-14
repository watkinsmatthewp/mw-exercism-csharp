using System;
using System.Collections.Generic;
using System.Text;

public static class Complement
{
    private static readonly Dictionary<char, char> DNA_TO_RNA_NUCLEOTIDE_MAPPINGS = new  Dictionary<char, char>
    {
        ['G'] = 'C',
        ['C'] = 'G',
        ['T'] = 'A',
        ['A'] = 'U'
    };
    
    public static string OfDna(string nucleotide)
    {
        var sb = new StringBuilder();
        foreach (var c in nucleotide)
        {
            sb.Append(DNA_TO_RNA_NUCLEOTIDE_MAPPINGS[c]);
        }
        return sb.ToString();
    }
}