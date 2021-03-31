using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Hamming
{
    /// <summary>
    /// Calculate the Hamming difference between two DNA strands.
    /// </summary>
    /// <param name="dna1">DNA strand one</param>
    /// <param name="dna2">DNA strand two</param>
    /// <returns>The Hamming difference</returns>
    public static int Distance(string dna1, string dna2)
    {
        if(dna1 is null) throw new ArgumentException("Must not be null", "dna1");
        if(dna2 is null) throw new ArgumentException("Must not be null", "dna2");
        if(dna1.Length != dna2.Length) throw new ArgumentException("dna1 must be the same length");

        int diff = 0;
        for(int i = 0; i < dna1.Length && i < dna2.Length; i++)
        {
            if(dna1[i] != dna2[i]) diff++;
        }
        return diff;
    }
}
