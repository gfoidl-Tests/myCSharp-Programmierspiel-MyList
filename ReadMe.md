[![Build status](https://ci.appveyor.com/api/projects/status/mjxnts4amdl27o3o?svg=true)](https://ci.appveyor.com/project/GntherFoidl/mycsharp-programmierspiel-mylist)


# Aufgabe

Implementiere eine Listen-Klasse, die das folgende Interface implementiert:

```
public interface IList<T> : IEnumerable<T>
{
    T this[int index] { get; }
    int Count { get; }
    void Add(T item);
    void Insert(int index, T item);
    void Clear();
    bool Contains(T item);
    IEnumerator<T> GetEnumerator();
    int IndexOf(T item);
    bool Remove(T item);    
    void RemoveAt(int index);   
}
```

## Folgende Regeln sind zu beachten

Es dürfen weder Arrays noch Collections / Collectionähnliche / Dictionaries / Dictionary-ähnliche Klassen aus dem Framework verwendet werden.