using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class LinkedList<T> : IEnumerable<LinkedList<T>>, IEquatable<LinkedList<T>>, IComparable<LinkedList<T>>
{
    public T? Value { get; private set; }
    public LinkedList<T>? Next { get; private set; }
    public LinkedList<T>? Previous { get; private set; }
    public int Length {get => this.Count(); }

    public LinkedList() {}
    public LinkedList(T value) : this( new[] { value } )
    {}

    public LinkedList(IEnumerable<T> values)
    {
        this.Value = values.First();
        var current = this;

        foreach(T next in values.Skip(1))
        {
            current.Next = new LinkedList<T>(next);
            current.Next.Previous = current;
            current = current.Next;
        }
    }

    public void Add(T value)
    {
        LinkedList<T> add = new LinkedList<T>(value);
        add.Previous = this.Last();
        this.Last().Next = add;
    }

    public IEnumerator<LinkedList<T>> GetEnumerator()
    {
        var current = this;
        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public LinkedList<T> this[int index] { get => this.AsEnumerable().ToArray()[index]; }

    public bool Equals(LinkedList<T>? other)
    {
        if(other is null || this.Length != other.Length) return false;
        for(int i = 0; i < this.Length; i++) if (this[i] != other[i]) return false;
        return true;
    }

    public override bool Equals([NotNullWhen(true)] object? other) => other is LinkedList<T> && this.Equals(other);

    public override int GetHashCode()
    {
        var values = this.Select(x => x.Value);
        return HashCode.Combine(values);
    }

    public LinkedList<T> GetShortest(params LinkedList<T>[] lists)
    {
        LinkedList<T> shortest = lists.First();
        foreach(var list in lists.Skip(1))
        {
            if(list.Length < shortest.Length) shortest = list;

        }
        return shortest;
    }

    public int CompareTo(LinkedList<T>? other)
    {
        if(other is null) return 1;
        int bigger, less = 0;
        return 0;
    }
}
