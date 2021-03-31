using System;
using System.Collections.Generic;
using System.Linq;

public class Allergies
{
    [Flags]
    private enum Allergen
    {
        none = 0,
        eggs = 1,
        peanuts = 2,
        shellfish = 4,
        strawberries = 8,
        tomatoes = 16,
        chocolate = 32,
        pollen = 64,
        cats = 128
    };

    private readonly int _score;

    public Allergies(int score)
    {
        _score = score;
    }

    public bool AllergicTo(string item)
    {
        return List().Any(a => a.Equals(item, StringComparison.CurrentCultureIgnoreCase));
    }

    public IEnumerable<string> List()
    {
        return Enum.GetValues(typeof(Allergen))
                   .Cast<Allergen>()
                   .Where(AllergicTo)
                   .Select(a => a.ToString());
    }

    private bool AllergicTo(Allergen allergen)
    {
        return ((int)allergen & _score) != 0;
    }
}