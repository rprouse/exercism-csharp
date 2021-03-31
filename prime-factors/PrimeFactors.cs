using System.Collections.Generic;

public static class PrimeFactors
{
    public static IEnumerable<long> For( long i )
    {
        int factor = 2;
        while ( i > 1 )
        {
            while ( i % factor != 0 ) factor++;
            i /= factor;
            yield return factor;
        }
    }
}