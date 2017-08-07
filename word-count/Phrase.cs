using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class Phrase
{
    public static Dictionary<string,int> WordCount(string input)
    {
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Search the input for all words (that may or may not contain an apostrophe in the middle)
        Regex regex = new Regex(@"\b\w+(\'\w+)*\b");
        foreach (Match match in regex.Matches(input))
        {
            string matchValue = match.Value.ToLowerInvariant();
            if (!wordCounts.ContainsKey(matchValue))
            {
                wordCounts[matchValue] = 0;
            }
            wordCounts[matchValue]++;
        }

        return wordCounts;
    }
}