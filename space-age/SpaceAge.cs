using System;

public class SpaceAge
{
    public const double EARTH_YEAR   = 31557600;    // seconds
    public const double MERCURY_YEAR = 0.2408467;  // Earth years
    public const double VENUS_YEAR   = 0.61519726; // Earth years
    public const double MARS_YEAR    = 1.8808158;  // Earth years
    public const double JUPITER_YEAR = 11.862615;  // Earth years
    public const double SATURN_YEAR  = 29.447498;  // Earth years
    public const double URANUS_YEAR  = 84.016846;  // Earth years
    public const double NEPTUNE_YEAR = 164.79132;  // Earth years

    public SpaceAge(ulong seconds)
    {
        Seconds = seconds;
    }

    public ulong Seconds { get; private set; }

    public double OnEarth()
    {
        return Math.Round(OnEarthAccurate, 2);
    }

    public double OnMercury()
    {
        return Calculate(MERCURY_YEAR);
    }

    public double OnVenus()
    {
        return Calculate(VENUS_YEAR);
    }

    public double OnMars()
    {
        return Calculate(MARS_YEAR);
    }

    public double OnJupiter()
    {
        return Calculate(JUPITER_YEAR);
    }

    public double OnSaturn()
    {
        return Calculate(SATURN_YEAR);
    }

    public double OnUranus()
    {
        return Calculate(URANUS_YEAR);
    }

    public double OnNeptune()
    {
        return Calculate(NEPTUNE_YEAR);
    }

    private double Calculate(double earthYears)
    {
        return Math.Round(OnEarthAccurate / earthYears, 2);
    }

    private double OnEarthAccurate { get { return Seconds / EARTH_YEAR; } }
}
