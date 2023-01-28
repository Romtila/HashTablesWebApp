using System.Collections;

namespace HashTablesWebApp.Models;

public class LinkedList<T> : ICollection<T>
{
    private Cell<T> _head;
    private Cell<T> _tail;

    public LinkedList()
    {
        _head = new Cell<T>(default);
        _tail = _head;
    }

    public void Add(T item)
    {
        _tail.Next = new Cell<T>(item);
        _tail = _tail.Next;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        var cell = _head;
        while (cell.Next != null)
        {
            if (cell.Next.Value!.Equals(item))
            {
                cell.Next = cell.Next.Next;
                if (cell.Next == null)
                {
                    _tail = cell;
                }
                return true;
            }
            cell = cell.Next;
        }

        return false;
    }

    public int Count { get; }
    public bool IsReadOnly { get; }

    public IEnumerator<T> GetEnumerator()
    {
        var cell = _head.Next;
        while (cell != null)
        {
            yield return cell.Value!;
            cell = cell.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Cell<T>
{
    public int? Key { get; set; }
    public T? Value { get; set; }
    public Cell<T>? Next { get; set; }

    public Cell(T? value)
    {
        Value = value;
    }

    public Cell(int key, T value, Cell<T>? cell)
    {
        Key = key;
        Value = value;
        Next = cell;
    }
    
    public Cell<T>? this[int index]
    {
        get
        {
            var cell = this;
            for (var i = 0; i < index; i++)
            {
                if (cell is null)
                    return null;
                
                cell = cell.Next;
            }

            return cell;
        }
    }
}