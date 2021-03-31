using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Cipher
{
    static Random _random = new Random();

    public Cipher() : this(new string(RandomKeys().Take(100).ToArray()))
    {
    }

    public Cipher(string key)
    {
        CheckKey(key);
        Key = key;
    }

    public string Key { get; set; }

    public string Encode(string plaintext) => Transform(plaintext, AddChar);

    public string Decode(string ciphertext) => Transform(ciphertext, SubtractChar);

    string Transform(string initial, Func<char, char, char> func)
    {
        var transformed = new StringBuilder(initial.Length);
        for(int i = 0; i < initial.Length; i++)
        {
            char c = initial[i];
            char k = (char)(Key[i % Key.Length] - 'a');
            char t = func(c, k);
            transformed.Append(t);
        }
        return transformed.ToString();
    }

    void CheckKey(string key)
    {
        if(Regex.Match(key, "[^a-z]+").Success)
            throw new ArgumentException("Key must only contain lowercase letters");

        if(key.Length == 0)
            throw new ArgumentException("Key must contain values");
    }

    static IEnumerable<char> RandomKeys()
    {
        while(true)
            yield return (char)('a' + (char)_random.Next(26));
    }

    static char SubtractChar(char a, char b)
    {
        int i = a - b - 'a';
        if(i < 0) i += 26;
        return (char)(i + 'a');
    }
    static char AddChar(char a, char b)
    {
        int i = a + b - 'a';
        return (char)(i % 26 + 'a');
    }
}
