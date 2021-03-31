/// <summary>
/// Utility methods for working with years
/// </summary>
public static class Leap
{
    /// <summary>
    /// Determines if the given year is a leap year
    /// </summary>
    /// <param name="year">The year in question</param>
    /// <returns>True if the given year is a leap year</returns>
    public static bool IsLeapYear(uint year)
    {
        if (year % 400 == 0) return true;
        if (year % 100 == 0) return false;
        return (year % 4 == 0);
    }
}
