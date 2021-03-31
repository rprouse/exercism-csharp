using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class NucleotideCount
{
    const char ADENINE  = 'A';
    const char CYTOSINE = 'C';
    const char GUANINE  = 'G';
    const char THYMINE  = 'T';
    static char[] NUCLEOTIDES = new[] {
        ADENINE, CYTOSINE, GUANINE, THYMINE
    };

    public static IDictionary<char, int> Count(string dnaString)
    {
        if(dnaString == null) throw new ArgumentException("Cannot be null", "dnaString");

        var counts = new Dictionary<char, int>();

        foreach(char nucleotide in NUCLEOTIDES)
            counts[nucleotide] = 0;

        foreach(char nucleotide in dnaString.Select(c => ValididateNucleotide(c)))
            counts[nucleotide]++;

        return counts;
    }

    static char ValididateNucleotide(char nucleotide)
    {
        nucleotide = (from n in NUCLEOTIDES
                      where n == Char.ToUpper(nucleotide)
                      select n).FirstOrDefault();

        if(nucleotide == default(char))
            throw new ArgumentException();
        return nucleotide;
    }
}