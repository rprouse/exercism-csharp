using System;

public static class ResistorColor
{
    static readonly string[] colors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) =>
        Array.IndexOf(colors, color);

    public static string[] Colors() => colors;
}