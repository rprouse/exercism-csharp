using Xunit;


public class ScrabbleScoreTest
{
    [Fact]
    public void Empty_word_scores_zero()
    {
        Assert.Equal(0, new Scrabble("").Score());
    }

    [Fact]
    public void Whitespace_scores_zero()
    {
        Assert.Equal(0, new Scrabble(" \t\n").Score());
    }

    [Fact]
    public void Null_scores_zero()
    {
        Assert.Equal(0, new Scrabble(null).Score());
    }

    [Fact]
    public void Scores_very_short_word()
    {
        Assert.Equal(1, new Scrabble("a").Score());
    }

    [Fact]
    public void Scores_other_very_short_word()
    {
        Assert.Equal(4, new Scrabble("f").Score());
    }

    [Fact]
    public void Simple_word_scores_the_number_of_letters()
    {
        Assert.Equal(6, new Scrabble("street").Score());
    }

    [Fact]
    public void Complicated_word_scores_more()
    {
        Assert.Equal(22, new Scrabble("quirky").Score());
    }

    [Fact]
    public void Scores_are_case_insensitive()
    {
        Assert.Equal(20, new Scrabble("MULTIBILLIONAIRE").Score());
    }

    [Fact]
    public void Convenient_scoring()
    {
        Assert.Equal(13, Scrabble.Score("alacrity"));
    }
}