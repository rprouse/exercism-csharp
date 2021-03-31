using System.Collections.Generic;
using System.Linq;
using System;


public static class Strain
{
    public static IEnumerable<T> Keep<T>( this IEnumerable<T> collection, Predicate<T> keep )
    {
        foreach ( var item in collection )
        {
            if ( keep( item ) )
                yield return item;
        }
    }

    public static IEnumerable<T> Discard<T>( this IEnumerable<T> collection, Predicate<T> discard )
    {
        foreach ( var item in collection )
        {
            if ( !discard( item ) )
                yield return item;
        }
    }
}
