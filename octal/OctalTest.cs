using Xunit;


public class OctalTest
{
    // change Ignore to false to run test case or just remove 'Ignore = "Todo"'
    [Theory]
    [InlineData("1", 1)]
    [InlineData("10", 8)]
    [InlineData("17", 15)]
    [InlineData("11", 9)]
    [InlineData("130", 88)]
    [InlineData("2047", 1063)]
    [InlineData("7777", 4095)]
    [InlineData("1234567", 342391)]
    public void Octal_converts_to_decimal(string value, int expected)
    {
        Assert.Equal(expected, Octal.ToDecimal(value));
    }

    [Theory]
    [InlineData("carrot")]
    [InlineData("8")]
    [InlineData("9")]
    [InlineData("6789")]
    [InlineData("abc1z")]
    public void Invalid_octal_is_decimal_0(string invalidValue)
    {
        Assert.Equal(0, Octal.ToDecimal(invalidValue));
    }

    [Fact]
    public void Octal_can_convert_formatted_strings()
    {
        Assert.Equal(9, Octal.ToDecimal("011"));
    }
}