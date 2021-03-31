using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Phrase
{
    private readonly string _phrase;

    public Phrase(string phrase)
    {
        if (phrase == null) throw new ArgumentNullException("phrase");
        _phrase = phrase;
    }

    /// <summary>
    /// Gets a word count on this phrase
    /// </summary>
    /// <returns>The count of each unique word</returns>
    public IDictionary<string, int> WordCount()
    {
        var counts = new Dictionary<string, int>();
        Match match = Regex.Match(_phrase.ToLower(), @"\w+'\w+|\w+");
        while(match.Success)
        {
            string word = match.Value;
            if(!counts.ContainsKey(word))
            {
                counts[word] = 0;
            }
            counts[word]++;
            match = match.NextMatch();
        }
        return counts;
    }
}
