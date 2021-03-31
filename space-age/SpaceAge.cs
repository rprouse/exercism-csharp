using System;

public class SpaceAge
{
    const double EARTH_YEAR   = 31557600;    // seconds
    const double MERCURY_YEAR = 0.2408467;  // Earth years
    const double VENUS_YEAR   = 0.61519726; // Earth years
    const double MARS_YEAR    = 1.8808158;  // Earth years
    const double JUPITER_YEAR = 11.862615;  // Earth years
    const double SATURN_YEAR  = 29.447498;  // Earth years
    const double URANUS_YEAR  = 84.016846;  // Earth years
    const double NEPTUNE_YEAR = 164.79132;  // Earth years

    public SpaceAge(ulong seconds)
    {
        Seconds = seconds;
    }

    public ulong Seconds { get; }

    public double OnEarth() =>
        Math.Round(OnEarthAccurate, 2);

    public double OnMercury() => Calculate(MERCURY_YEAR);

    public double OnVenus() => Calculate(VENUS_YEAR);

    public double OnMars() => Calculate(MARS_YEAR);

    public double OnJupiter() => Calculate(JUPITER_YEAR);

    public double OnSaturn() => Calculate(SATURN_YEAR);

    public double OnUranus() => Calculate(URANUS_YEAR);

    public double OnNeptune() => Calculate(NEPTUNE_YEAR);

    private double Calculate(double earthYears) =>
        Math.Round(OnEarthAccurate / earthYears, 2);

    private double OnEarthAccurate => Seconds / EARTH_YEAR;
}
