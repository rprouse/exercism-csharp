using System.Collections.Generic;
using Xunit;
using System;


public class GradeSchoolTest
{
    private School school;

    public GradeSchoolTest()
    {
        school = new School();
    }

    [Fact]
    public void New_school_has_an_empty_roster()
    {
        Assert.Equal(0, school.Roster.Count);
    }

    [Fact]
    public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
    {
        school.Add("Aimee", 2);
        var expected = new List<string> { "Aimee" };
        Assert.Equal(school.Roster[2], expected);
    }

    [Fact]
    public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
    {
        school.Add("Blair", 2);
        school.Add("James", 2);
        school.Add("Paul", 2);
        var expected = new List<string> { "Blair", "James", "Paul" };
        Assert.Equal(school.Roster[2], expected);
    }

    [Fact]
    public void Adding_students_to_different_grades_adds_them_to_the_roster()
    {
        school.Add("Chelsea", 3);
        school.Add("Logan", 7);
        Assert.Equal(school.Roster[3], new List<string> { "Chelsea" });
        Assert.Equal(school.Roster[7], new List<string> { "Logan" });
    }

    [Fact]
    public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
    {
        school.Add("Franklin", 5);
        school.Add("Bradley", 5);
        school.Add("Jeff", 1);
        var expected = new List<string> { "Bradley", "Franklin" };
        Assert.Equal(school.Grade(5), expected);
    }

    [Fact]
    public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
    {
        Assert.Equal(school.Grade(1), new List<string>());
    }

    [Fact]
    public void Student_names_in_each_grade_in_roster_are_sorted()
    {
        school.Add("Jennifer", 4);
        school.Add("Kareem", 6);
        school.Add("Christopher", 4);
        school.Add("Kyle", 3);
        Assert.Equal(school.Roster[3], new List<string> { "Kyle" });
        Assert.Equal(school.Roster[4], new List<string> { "Christopher", "Jennifer" });
        Assert.Equal(school.Roster[6], new List<string> { "Kareem" });
    }

    [Fact]
    public void Roster_is_immutable()
    {
        Assert.Throws<NotSupportedException>(() => school.Roster.Add(1, new SortedSet<string>()));
    }

    [Fact]
    public void Grade_through_roster_is_immutable()
    {
        school.Add("Jennifer", 4);
        Assert.Throws<NotSupportedException>(() => school.Roster[4].Add("John"));
        Assert.Equal(1, school.Roster[4].Count);
        Assert.Equal(1, school.Grade(4).Count);
    }

    [Fact]
    public void Grade_is_immutable()
    {
        school.Add("Jennifer", 4);
        Assert.Throws<NotSupportedException>(() => school.Grade(4).Add("John"));
        Assert.Equal(1, school.Roster[4].Count);
        Assert.Equal(1, school.Grade(4).Count);
    }
}