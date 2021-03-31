using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Crypto
{
    public Crypto( string plaintext )
    {
        NormalizePlaintext = Normalize( plaintext );
        Size = GetSegmentSize(NormalizePlaintext);
    }

    public string NormalizePlaintext { get; private set; }
    public int Size { get; private set; }

    public IEnumerable<string> PlaintextSegments()
    {
        return SplitIntoSegments( NormalizePlaintext, Size );
    }

    public string Ciphertext()
    {
        var builder = new StringBuilder( NormalizePlaintext.Length );
        for ( int offset = 0; offset < Size; offset++ )
        {
            for ( int i = 0; i + offset < NormalizePlaintext.Length; i += Size )
            {
                builder.Append( NormalizePlaintext[i + offset] );
            }
        }
        return builder.ToString();
    }

    public string NormalizeCiphertext()
    {
        string cipher = Ciphertext();
        int size = cipher.Length > Size * Size - Size ? Size : Size - 1;
        return string.Join( " ", SplitIntoSegments( cipher, size ) );
    }

    private static string Normalize( string text )
    {
        return Regex.Replace( text, @"[^\w]", "" ).ToLower();
    }

    private static int GetSegmentSize( string text )
    {
        return ( int )Math.Ceiling( Math.Sqrt( text.Length ) );
    }

    private IEnumerable<string> SplitIntoSegments( string text, int size )
    {
        for ( int i = 0; i < text.Length; i += size )
        {
            int len = Math.Min( size, text.Length - i );
            yield return text.Substring( i, len );
        }
    }
}