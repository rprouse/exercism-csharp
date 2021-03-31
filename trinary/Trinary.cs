using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Trinary
{
    private readonly string _value;

    public Trinary(string value)
    {
        _value = IsValid(value) ? value : "0";
    }

    public int ToDecimal()
    {
        return _value.Reverse()
                     .Select(IntegerValue)
                     .Select(Base3ToBase10)
                     .Sum();
    }

    private int IntegerValue(char c)
    {
        return c - '0';
    }

    private int Base3ToBase10(int digit, int place)
    {
        return digit * (int)Math.Pow(3, place);
    }

    private static bool IsValid(string trinary)
    {
        return !string.IsNullOrWhiteSpace( trinary ) &&
            !Regex.Match(trinary, "[^0-2]").Success;
    }
}