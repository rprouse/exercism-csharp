using System;
using System.Collections.Generic;
using System.Text;

public static class RomanNumerals
{
    // The roman numerals for various numeric values
    private static readonly IList<Tuple<int, string>> _numerals = new List<Tuple<int, string>>()
    {
        new Tuple<int, string>(1000, "M"),
        new Tuple<int, string>( 900, "CM"),
        new Tuple<int, string>( 500, "D"),
        new Tuple<int, string>( 400, "CD"),
        new Tuple<int, string>( 100, "C"),
        new Tuple<int, string>(  90, "XC"),
        new Tuple<int, string>(  50, "L"),
        new Tuple<int, string>(  40, "XL"),
        new Tuple<int, string>(  10, "X"),
        new Tuple<int, string>(   9, "IX"),
        new Tuple<int, string>(   5, "V"),
        new Tuple<int, string>(   4, "IV"),
        new Tuple<int, string>(   1, "I")
    };

    /// <summary>
    /// Converts a given number into a roman numeral
    /// </summary>
    public static String ToRoman( this int n )
    {
        if(n < 0 || n > 3999) throw new ArgumentException("The value must be between 0 and 3999");
        var result = new StringBuilder();
        foreach ( Tuple<int, string> numeral in _numerals )
        {
            while ( n >= numeral.Item1 )
            {
                result.Append( numeral.Item2 );
                n -= numeral.Item1;
            }
        }
        return result.ToString();
    }
}