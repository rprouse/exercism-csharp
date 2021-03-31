using System;
using System.Linq;

public static class Raindrops
{
    private static readonly Tuple<int, string>[] rain =
        {
            new Tuple<int, string>( 3, "Pling" ), 
            new Tuple<int, string>( 5, "Plang" ), 
            new Tuple<int, string>( 7, "Plong" )
        };

    public static string Convert(int number)
    {
        var words = (from pair in rain 
                     where number % pair.Item1 == 0 
                     select pair.Item2).ToArray();
        return words.Any() ? String.Concat(words) : number.ToString();
    }
}