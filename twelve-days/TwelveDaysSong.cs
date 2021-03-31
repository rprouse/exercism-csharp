using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TwelveDaysSong
{
    private static readonly string[] DAYS =
    {
        "first", "second", "third", "fourth", "fifth", "sixth", 
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
    };

    private const string FIRST_GIFT = "a Partridge in a Pear Tree.";

    private static readonly string[] GIFTS =
    {
        "twelve Drummers Drumming, ",
        "eleven Pipers Piping, ",
        "ten Lords-a-Leaping, ",
        "nine Ladies Dancing, ",
        "eight Maids-a-Milking, ",
        "seven Swans-a-Swimming, ",
        "six Geese-a-Laying, ",
        "five Gold Rings, ",
        "four Calling Birds, ",
        "three French Hens, ",
        "two Turtle Doves, ",
        "and " + FIRST_GIFT
    };

    private const string VERSE = "On the {0} day of Christmas my true love gave to me, {1}\n";

    /// <summary>
    /// Gets the given verse of the song
    /// </summary>
    /// <param name="verse">The verse to display</param>
    /// <returns>The requested verse</returns>
    public string Verse(int verse)
    {
        if(verse < 1 || verse > 12) 
            throw new ArgumentException("Verse must be between 1 and 12");
        var gifts = verse > 1 ? 
            GIFTS.Skip(12 - verse).Take(verse) : 
            new[] { FIRST_GIFT };
        return string.Format(VERSE, DAYS[verse - 1], string.Concat(gifts));
    }

    /// <summary>
    /// Gets verses of the song
    /// </summary>
    /// <param name="start">The first verse, inclusive</param>
    /// <param name="end">The last verse, inclusive</param>
    /// <returns>The requested verses</returns>
    public string Verses(int start, int end)
    {
        if (end < start) 
            throw new ArgumentException("End must be greater than start");
        var verses = from verse in Enumerable.Range(start, end - start + 1) 
                     select Verse(verse) + "\n";
        return string.Concat(verses);
    }

    /// <summary>
    /// Gets the entire song
    /// </summary>
    /// <returns>The song</returns>
    public string Sing()
    {
        return Verses(1, 12);
    }
}
