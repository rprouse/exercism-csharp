using System;
using System.Linq;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    string _diagram;
    IEnumerable<string> _students;

    static IDictionary<char, Plant> _plants = new Dictionary<char, Plant>();

    static KindergartenGarden()
    {
        var plants = (Plant[])Enum.GetValues(typeof(Plant));
        foreach(var plant in plants)
            _plants.Add(plant.ToString()[0], plant);
    }

    public KindergartenGarden(string diagram)
        : this(diagram, new[] {"Alice", "Bob", "Charlie", "David",
                               "Eve", "Fred", "Ginny", "Harriet",
                               "Ileana", "Joseph", "Kincaid", "Larry"})
    {
    }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
        _diagram = diagram;
        _students = students.OrderBy(s => s);
    }

    public IEnumerable<Plant> Plants(string student)
    {
        int index = GetStudentIndex(student);
        var rows = GetPlantRows();
        yield return GetPlant(rows[0],index);
        yield return GetPlant(rows[0],index+1);
        yield return GetPlant(rows[1],index);
        yield return GetPlant(rows[1],index+1);
    }

    // This returns the index into the plant rows, not
    // the index into the student list
    int GetStudentIndex(string student)
    {
        int index = 0;
        foreach(var s in _students)
        {
            if(student.Equals(s)) return index*2;
            index++;
        }
        throw new ArgumentException(nameof(student), "The student must be in the class");
    }

    string[] GetPlantRows()
    {
        var rows = _diagram.Split('\n');
        if(rows.Length != 2) throw new ArgumentException("The diagram must contain two rows");
        return rows;
    }

    Plant GetPlant(string row, int index)
    {
        if(index > row.Length - 1)
            throw new ArgumentException("There are more students than plants");

        var plant = row[index];

        if(!_plants.ContainsKey(plant))
            throw new ArgumentException($"Unknown plant {plant}");

        return _plants[plant];
    }
}