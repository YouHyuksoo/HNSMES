using System;
using System.Collections;
using System.Collections.Generic;

namespace IDAT_Common.DATA.IDATLIST;

public class IDATAggregation<T> : ICollection, IEnumerable
{
	private IList<T> elements = new List<T>();

	private int pos = -1;

	private IList<T> Items => elements;

	public int Count => elements.Count;

	public T Current => elements[pos];

	public T this[int index] => elements[index];

	public int Index => pos;

	public bool IsSynchronized
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public object SyncRoot
	{
		get
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}

	public void Add(T item)
	{
		elements.Add(item);
		pos++;
	}

	public void Clear()
	{
		elements.Clear();
		pos = -1;
	}

	public void Remove(int indeX)
	{
		if (indeX < elements.Count)
		{
			elements.RemoveAt(indeX);
		}
	}

	public void Enqueue(T item)
	{
		elements.Add(item);
	}

	public void Dequeue()
	{
		elements.Remove(elements[0]);
	}

	public IEnumerator GetEnumerator()
	{
		foreach (T item in elements)
		{
			yield return item;
		}
	}

	public bool MoveBegin()
	{
		if (0 < elements.Count)
		{
			pos = 0;
			return true;
		}
		return false;
	}

	public bool MoveNext()
	{
		if (pos < elements.Count)
		{
			pos++;
			return true;
		}
		return false;
	}

	public bool MovePrev()
	{
		if (pos > 0)
		{
			pos--;
			return true;
		}
		return false;
	}

	public bool MoveEnd()
	{
		if (0 < elements.Count)
		{
			pos = elements.Count - 1;
			return true;
		}
		return false;
	}

	public void Reset()
	{
		if (elements.Count > 0)
		{
			pos = 0;
		}
	}

	public void Push(T item)
	{
		elements.Add(item);
		pos++;
	}

	public void Pop()
	{
		elements.Remove(elements[elements.Count - 1]);
		pos--;
	}

	public void CopyTo(Array array, int index)
	{
		throw new Exception("The method or operation is not implemented.");
	}
}
