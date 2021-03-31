using System.Collections.Generic;
using System.Linq;

public class Scrabble
{
    private static readonly Dictionary<char, int> _values = new Dictionary<char, int>(26);
    private readonly string _word;

    static Scrabble()
    {
        var seed = new Dictionary<int, char[]>()
        {
            { 1, new []{'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'}},
            { 2, new []{'D', 'G'}},
            { 3, new []{'B', 'C', 'M', 'P'}},
            { 4, new []{'F', 'H', 'V', 'W', 'Y'}},
            { 5, new []{'K'}},
            { 8, new []{'J', 'X'}},
            {10, new []{'Q', 'Z'}}
        };

        foreach (int score in seed.Keys)
            foreach (var letter in seed[score])
                _values.Add(letter, score);
    }

    public Scrabble(string word)
    {
        _word = word;
    }

    public int Score()
    {
        return Score(_word);
    }

    public static int Score(string word)
    {
        if (word == null) return 0;
        return word.ToUpper()
            .Where(letter => _values.ContainsKey(letter))
            .Sum(letter => _values[letter]);
    }
}