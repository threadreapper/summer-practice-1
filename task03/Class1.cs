namespace task03;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomCollection<T> : IEnumerable<T>
{
    private readonly List<T> _items = [];

    public void Add(T item) => _items.Add(item);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerable<T> GetReverseEnumerator()
    {
        foreach (var item in _items.AsEnumerable().Reverse())
        {
            yield return item;
        }
    }
    public static IEnumerable<int> GenerateSequence(int start, int count) => Enumerable.Range(start, count);
    public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector) => _items.Where(predicate).OrderBy(keySelector);
}
