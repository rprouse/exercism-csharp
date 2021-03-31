using System;
using System.Collections.Generic;

public class Robot
{
    static readonly List<string> _usedName = new List<string>();
    static readonly Random _random = new Random();

    public Robot()
    {
        Reset();
    }

    public string Name { get; private set; }

    public void Reset()
    {
        string name = RandomName;
        while(_usedName.Contains(name))
            name = RandomName;

        Name = name;
        _usedName.Add(name);
    }

    static string RandomName =>
        $"{RandomLetter}{RandomLetter}{RandomDigits:000}";

    static char RandomLetter => (char)('A' + _random.Next(26));

    static int RandomDigits => _random.Next(1000);
}