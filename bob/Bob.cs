using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Bob
{
    public static string Hey(string input)
    {
        input = input.Trim();
        if (String.IsNullOrWhiteSpace(input))
        {
            return "Fine. Be that way!";
        }

        IEnumerable<char> letters = input.ToCharArray().Where(c => Char.IsLetter(c));
        if (letters.Any() && letters.All(c => Char.IsUpper(c)))
        {
            return "Whoa, chill out!";
        }

        if (input.EndsWith("?"))
        {
            return "Sure.";
        }

        return "Whatever.";
    }
}