using System;
using System.Linq;

public static class Octal
{
    public static int ToDecimal(string value)
    {
        try
        {
            int i = value.Length - 1;
            return value.Select( oct => Parse(oct) * (int)Math.Pow(8, i--) ).Sum();
        }
        catch(ArgumentException)
        {
            return 0;
        }
    }

    /// <summary>
    /// Parse a character representing an octal digit in a
    /// string into its numeric format
    /// </summary>
    static int Parse(char c)
    {
        if(c < '0' || c > '7')
            throw new ArgumentException("Must be 0 through 7", nameof(c));

        return c - '0';
    }
}
