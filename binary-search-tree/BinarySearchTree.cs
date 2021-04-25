using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        Value = values.First();
        foreach(var val in values.Skip(1))
            Add(val);
    }

    public int Value { get; init; }

    public BinarySearchTree Left { get; private set;}

    public BinarySearchTree Right { get; private set;}

    public BinarySearchTree Add(int value)
    {
        if (value < Value)
            Left = Left?.Add(value) ?? new BinarySearchTree(value);
        else
            Right = Right?.Add(value) ?? new BinarySearchTree(value);
        return this;
    }

    public IEnumerator<int> GetEnumerator() =>
        ((IEnumerable<int>)GetData()).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        ((IEnumerable)GetData()).GetEnumerator();

    private IEnumerable<int> GetData()
    {
        foreach(var val in Left ?? Enumerable.Empty<int>())
            yield return val;

        yield return Value;

        foreach(var val in Right ?? Enumerable.Empty<int>())
            yield return val;
    }
}