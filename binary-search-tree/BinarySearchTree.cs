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
        new BinarySearchTreeEnumerator(this);

    IEnumerator IEnumerable.GetEnumerator() =>
        new BinarySearchTreeEnumerator(this);

    class BinarySearchTreeEnumerator : IEnumerator, IEnumerator<int>
    {
        BinarySearchTree _bst;
        List<int> _list;
        IEnumerator<int> _enumerator;

        public BinarySearchTreeEnumerator(BinarySearchTree bst)
        {
            _bst = bst;
            Reset();
        }

        public int Current => _enumerator.Current;

        object IEnumerator.Current => _enumerator.Current;

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public bool MoveNext() => _enumerator.MoveNext();
        public void Reset()
        {
            _list = _bst.Left?.ToList() ?? new List<int>();
            _list.Add(_bst.Value);
            _list.AddRange(_bst.Right.ToArray() ?? new int[] {} );
            _enumerator = ((IEnumerable<int>)_list).GetEnumerator();
        }
    }
}