using System;
using System.Collections.Generic;
using System.Linq;

public static class AccumulateExtensions
{
    public static IEnumerable<T2> Accumulate<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> operation )
    {
        return source.Select( operation );
    }
}
