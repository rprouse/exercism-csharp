using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Atbash
{
    private static readonly Regex regex = new Regex( @"[^\w]", RegexOptions.Compiled );

    public static string Encode( string words )
    {
        var builder = new StringBuilder();
        int count = 1;
        foreach ( char c in StripWhitespace( words ) )
        {
            builder.Append( Encode( c ) );
            if ( count++ % 5 == 0 )
                builder.Append( ' ' );
        }
        return builder.ToString().TrimEnd();
    }

    private static string StripWhitespace( string words )
    {
        return regex.Replace( words.ToLower(), "" );
    }

    private static char Encode( char c )
    {
        if ( Char.IsDigit( c ) )
            return c;

        return (char)( 'z' - c + 'a' );
    }
}