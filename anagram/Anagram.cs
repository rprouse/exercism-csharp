using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Exercism.io
/// </summary>
public class Anagram
{
    private readonly string _match;
    private readonly string _sortedMatch;

    /// <summary>
    /// Constructs an Anagram class to find anagrams in lists of words
    /// </summary>
    /// <param name="match">The word to find anagrams for.</param>
    public Anagram(string match)
    {
        if(String.IsNullOrWhiteSpace(match))
            throw new ArgumentException("match cannot be a null or empty string");
        _match = match;
        _sortedMatch = SortString(_match);
    }

    /// <summary>
    /// Given a list of words, finds those that are anagrams for
    /// the word the class was constructed with.
    /// </summary>
    /// <param name="words">The list of words</param>
    /// <returns>The words in the list that are anagrams of the 
    /// word passed in to the constructor.</returns>
    public IEnumerable<string> Match(IEnumerable<string> words)
    {
        var matched = from word in words 
                      where !string.IsNullOrWhiteSpace(word) && 
                            IsAnagram(word) 
                      orderby word
                      select word;
        return matched;
    }

    /// <summary>
    /// Determines if a word is an anagram 
    /// of the word passed in to the constructor.
    /// </summary>
    /// <param name="word">The word to check</param>
    /// <returns>True if the word is an anagram</returns>
    private bool IsAnagram(string word)
    {
        bool isAnagram = false;
        // The length comparison is not technically needed, but it is
        // much cheaper to short-circuit the subsequent conditions
        if(word.Length == _match.Length &&
           !word.Equals(_match, StringComparison.CurrentCultureIgnoreCase) &&
           SortString(word).Equals(_sortedMatch, StringComparison.CurrentCultureIgnoreCase))
        {
            isAnagram = true;
        }
        return isAnagram;
    }

    /// <summary>
    /// Sorts a string alphabetically
    /// </summary>
    /// <param name="str">The string to sort</param>
    /// <returns>The sorted string</returns>
    private string SortString(string str)
    {
        char[] c = str.ToCharArray();
        // Sort case-insensitive
        Array.Sort(c, (x, y) => char.ToLower(x) - char.ToLower(y));
        return new string(c);
    }
}
