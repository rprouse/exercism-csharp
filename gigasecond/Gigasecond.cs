using System;

public static class Gigasecond
{
    const double GIGASECOND = 1E9;

    /// <summary>
    /// Calculates the date that someone turned or will celebrate their 1 Gs anniversary.
    /// </summary>
    /// <returns></returns>
    public static DateTime Add(DateTime birthday) =>
        birthday.AddSeconds( GIGASECOND );
}
