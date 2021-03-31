using System;
using System.Collections.Generic;
using System.Linq;

public class Complement
{
    private static readonly Dictionary<char, char> _complements = new Dictionary<char, char>
    {
        {'G', 'C'},
        {'C', 'G'},
        {'T', 'A'},
        {'A', 'U'}
    };

    public static string OfDna(string dna)
    {
        return GetComplement(dna, RnaComplement);
    }

    public static string OfRna(string rna)
    {
        return GetComplement(rna, DnaComplement);
    }

    private static string GetComplement(string sequence, Func<char, char> complement)
    {
        return new string(sequence.Select(complement).ToArray());
    }

    private static char RnaComplement(char dna)
    {
        return _complements[dna];
    }

    private static char DnaComplement(char rna)
    {
        return (from pair in _complements 
                where pair.Value == rna 
                select pair.Key).FirstOrDefault();
    }
}