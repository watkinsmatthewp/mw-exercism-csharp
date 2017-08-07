using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Anagram
{
    private string _masterWord;
    private string _masterWordDescended = null;

    public Anagram(string masterWord)
    {
        _masterWord = masterWord;
    }

    public string[] Match(string[] words)
    {
        return words.Where(word => IsMatch(word)).ToArray();
    }

    private bool IsMatch(string word)
    {
        return _masterWord.Length == word.Length 
            && !_masterWord.Equals(word, StringComparison.OrdinalIgnoreCase)
            && HasSameLetters(word.ToLowerInvariant());
    }

    private bool HasSameLetters(string word)
    {
        if (_masterWordDescended == null)
        {
            // Lazy-load the characters of the master word in descending order
            _masterWordDescended = OrderCharacters(_masterWord.ToLowerInvariant());
        }

        // Compare the sorted characters of this string to the master
        return _masterWordDescended.Equals(OrderCharacters(word));
    }

    private string OrderCharacters(string word)
    {
        return new String(word.OrderByDescending(c => c).ToArray());
    }
}