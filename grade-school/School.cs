using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A simple school roster that lists the students
/// in each grade
/// </summary>
public class School
{
    private ImmutableDictionary<uint, ImmutableSortedSet<string>.Builder>.Builder _roster = ImmutableDictionary<uint, ImmutableSortedSet<string>.Builder>.Empty.ToBuilder();
    
    /// <summary>
    /// The school roster. The key is the grade, the value is the list
    /// of students for that grade.
    /// </summary>
    public IDictionary<uint, ISet<string>> Roster 
    {
        get
        {
            ImmutableDictionary<uint, ISet<string>>.Builder roster = ImmutableDictionary<uint, ISet<string>>.Empty.ToBuilder();
            foreach(var pair in _roster)
                roster.Add(pair.Key, pair.Value.ToImmutable());
            return roster.ToImmutable();
        }
    }

    /// <summary>
    /// Adds the given student to the given grade
    /// </summary>
    /// <param name="student"></param>
    /// <param name="grade"></param>
    public void Add(string student, uint grade)
    {
        if(string.IsNullOrWhiteSpace(student)) throw new ArgumentException("student cannot be null or empty");

        if (!_roster.ContainsKey(grade))
            _roster[grade] = ImmutableSortedSet<string>.Empty.ToBuilder();

        _roster[grade].Add(student);
    }

    /// <summary>
    /// Returns a list of students in the given grade
    /// </summary>
    /// <param name="grade">The grade</param>
    /// <returns>A list of students</returns>
    public ISet<string> Grade(uint grade)
    {
        if(!_roster.ContainsKey(grade))
            return ImmutableSortedSet<string>.Empty;
        return _roster[grade].ToImmutable();
    }
}
