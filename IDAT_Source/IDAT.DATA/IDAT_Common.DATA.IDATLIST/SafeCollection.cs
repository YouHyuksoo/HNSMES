using System;
using System.Collections;
using System.Collections.Generic;

namespace IDAT_Common.DATA.IDATLIST;

internal class SafeCollection<TKey, TValue>
{
	private class SafeEnumerator : IEnumerator, IDisposable
	{
		private SafeCollection<TKey, TValue> _list;

		private Dictionary<TKey, TValue>.Enumerator enumerator;

		public object Current => enumerator.Current;

		public bool MoveNext()
		{
			while (enumerator.MoveNext())
			{
				if (_list._RemoveList.Contains(enumerator.Current.Key))
				{
					continue;
				}
				return true;
			}
			return false;
		}

		public void Reset()
		{
		}

		public SafeEnumerator(SafeCollection<TKey, TValue> list)
		{
			_list = list;
			enumerator = _list.BaseGetEnumerator();
			_list.StartForeach();
		}

		public void Dispose()
		{
			_list.EndForeach();
		}
	}

	private Dictionary<TKey, TValue> _List = new Dictionary<TKey, TValue>();

	private Dictionary<TKey, TValue> _AddList = new Dictionary<TKey, TValue>();

	private List<TKey> _RemoveList = new List<TKey>();

	public uint bForeachCount = 0u;

	public Dictionary<TKey, TValue>.KeyCollection Keys => _List.Keys;

	public Dictionary<TKey, TValue>.ValueCollection Values => _List.Values;

	public void Clear()
	{
		if (bForeachCount == 0)
		{
			_List.Clear();
			return;
		}
		_AddList.Clear();
		_RemoveList.Clear();
		foreach (TKey key in _List.Keys)
		{
			_RemoveList.Add(key);
		}
	}

	public bool ContainsKey(TKey key)
	{
		if (_AddList.ContainsKey(key))
		{
			return true;
		}
		if (_RemoveList.Contains(key))
		{
			return false;
		}
		return _List.ContainsKey(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (bForeachCount == 0)
		{
			return _List.TryGetValue(key, out value);
		}
		if (_AddList.TryGetValue(key, out value))
		{
			return true;
		}
		if (_RemoveList.Contains(key))
		{
			return false;
		}
		return _List.TryGetValue(key, out value);
	}

	public void Add(TKey key, TValue value)
	{
		if (bForeachCount == 0)
		{
			_List.Add(key, value);
		}
		else
		{
			_AddList.Add(key, value);
		}
	}

	public void Remove(TKey key)
	{
		if (bForeachCount == 0)
		{
			_List.Remove(key);
			return;
		}
		if (_AddList.ContainsKey(key))
		{
			_AddList.Remove(key);
			return;
		}
		if (!_List.ContainsKey(key) || _RemoveList.Contains(key))
		{
			throw new Exception("dosen't have key");
		}
		_RemoveList.Add(key);
	}

	public void StartForeach()
	{
		bForeachCount++;
	}

	public void EndForeach()
	{
		bForeachCount--;
		if (bForeachCount != 0)
		{
			return;
		}
		foreach (TKey remove in _RemoveList)
		{
			_List.Remove(remove);
		}
		_RemoveList.Clear();
		foreach (KeyValuePair<TKey, TValue> add in _AddList)
		{
			_List.Add(add.Key, add.Value);
		}
		_AddList.Clear();
	}

	public Dictionary<TKey, TValue>.Enumerator BaseGetEnumerator()
	{
		return _List.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return new SafeEnumerator(this);
	}
}
