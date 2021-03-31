using Xunit;


public class TrinaryTest
{
    // change Ignore to false to run test case or just remove 'Ignore = "Todo"'
    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("10", 3)]
    [InlineData("11", 4)]
    [InlineData("100", 9)]
    [InlineData("112", 14)]
    [InlineData("222", 26)]
    [InlineData("1122000120", 32091)]
    public void Trinary_converts_to_decimal(string value, int expected)
    {
        Assert.Equal(expected, new Trinary(value).ToDecimal());
    }

    [Theory]
    [InlineData("carrot")]
    [InlineData("3")]
    [InlineData("6")]
    [InlineData("9")]
    [InlineData("124578")]
    [InlineData("abc1z")]
    public void Invalid_trinary_is_decimal_0(string invalidValue)
    {
        Assert.Equal(0, new Trinary(invalidValue).ToDecimal());
    }

    [Fact]
    public void Trinary_can_convert_formatted_strings()
    {
        Assert.Equal(4, new Trinary("011").ToDecimal());
    }
}