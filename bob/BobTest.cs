using Xunit;


public class BobTest
{
    private Bob teenager;

    public BobTest()
    {
        teenager = new Bob();
    }

    [Fact]
    public void Stating_something ()
    {
        Assert.Equal("Whatever.", teenager.Hey("Tom-ay-to, tom-aaaah-to."));
    }

    [Fact]
    public void Shouting ()
    {
        Assert.Equal("Whoa, chill out!", teenager.Hey("WATCH OUT!"));
    }

    [Fact]
    public void Asking_a_question ()
    {
        Assert.Equal("Sure.", teenager.Hey("Does this cryogenic chamber make me look fat?"));
    }

    [Fact]
    public void Asking_a_numeric_question ()
    {
        Assert.Equal("Sure.", teenager.Hey("You are, what, like 15?"));
    }

    [Fact]
    public void Talking_forcefully ()
    {
        Assert.Equal("Whatever.", teenager.Hey("Let's go make out behind the gym!"));
    }

    [Fact]
    public void Using_acronyms_in_regular_search ()
    {
        Assert.Equal("Whatever.", teenager.Hey("It's OK if you don't want to go to the DMV."));
    }

    [Fact]
    public void Forceful_questions ()
    {
        Assert.Equal("Whoa, chill out!", teenager.Hey("WHAT THE HELL WERE YOU THINKING?"));
    }

    [Fact]
    public void Shouting_numbers ()
    {
        Assert.Equal("Whoa, chill out!", teenager.Hey("1, 2, 3 GO!"));
    }

    [Fact]
    public void Only_numbers ()
    {
        Assert.Equal("Whatever.", teenager.Hey("1, 2, 3"));
    }

    [Fact]
    public void Question_with_only_numbers ()
    {
        Assert.Equal("Sure.", teenager.Hey("4?"));
    }

    [Fact]
    public void Shouting_with_special_characters ()
    {
        Assert.Equal("Whoa, chill out!", teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"));
    }

    [Fact]
    public void Shouting_with_no_exclamation_mark ()
    {
        Assert.Equal("Whoa, chill out!", teenager.Hey("I HATE YOU"));
    }

    [Fact]
    public void Statement_containing_question_mark ()
    {
        Assert.Equal("Whatever.", teenager.Hey("Ending with ? means a question."));
    }

    [Fact]
    public void Prattling_on ()
    {
        Assert.Equal("Sure.", teenager.Hey("Wait! Hang on. Are you going to be OK?"));
    }

    [Fact]
    public void Silence ()
    {
        Assert.Equal("Fine. Be that way!", teenager.Hey(""));
    }

    [Fact]
    public void Prolonged_silence ()
    {
        Assert.Equal("Fine. Be that way!", teenager.Hey("    "));
    }

    [Fact]
    public void Multiple_line_question ()
    {
        Assert.Equal("Whatever.", teenager.Hey("Does this cryogenic chamber make me look fat?\nno"));
    }
}
