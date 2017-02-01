using System;
using System.Collections;
using System.Collections.Generic;

namespace Inflames2K
{
	public class MyList<T> : IList<T>
	{
		private ListItem<T> _first;
		private ListItem<T> _last;
		private int 		_count = 0;
		//---------------------------------------------------------------------
		public T this[int index]
		{
			get
			{
				ListItem<T> item = this.GetItemInternal(index);
				return item.Value;
			}
			set
			{
				ListItem<T> item = this.GetItemInternal(index);
				item.Value = value;
			}
		}
		//---------------------------------------------------------------------
		public int Count { get { return _count; } }
		//---------------------------------------------------------------------
		public bool IsReadOnly { get; } = false;
		//---------------------------------------------------------------------
		public void Add(T value)
		{
			// null as value is allowed -> consumer has to handle this
			ListItem<T> item = new ListItem<T>(value);

			if (_last != null)
			{
				_last.Next = item;
				item.Previous = _last;
				_last = item;
			}
			else
			{
				_last = item;
				item.Previous = _first;
			}

			if (_first == null)
				_first = item;

			_count++;
		}
		//---------------------------------------------------------------------
		public void Clear()
		{
			_first = null;
			_last = null;
			_count = 0;
		}
		//---------------------------------------------------------------------
		public bool Contains(T item) => this.IndexOf(item) >= 0;
		//---------------------------------------------------------------------
		public void CopyTo(T[] array, int arrayIndex)
		{
			ListItem<T> current = _first;

			while (current != null)
			{
				array[arrayIndex++] = current.Value;
				current = current.Next;
			}
		}
		//---------------------------------------------------------------------
		public IEnumerator<T> GetEnumerator()
		{
			for (var current = _first; current != null; current = current.Next)
				yield return current.Value;
		}
		//---------------------------------------------------------------------
		public int IndexOf(T item)
		{
			ListItem<T> current = _first;
			int index 			= 0;

			while (current != null)
			{
				if (current.Value.Equals(item)) return index;
				index++;
				current = current.Next;
			}

			return -1;
		}
		//---------------------------------------------------------------------
		public void Insert(int index, T value)
		{
			if ((_count == 0 && index == 0) || (_count == index))
			{
				this.Add(value);
				return;
			}

			ListItem<T> item 	 = this.GetItemInternal(index);
			ListItem<T> toInsert = new ListItem<T>(value);

			item.Previous.Next = toInsert;
			toInsert.Previous  = item.Previous;
			item.Previous 	   = toInsert;
			toInsert.Next 	   = item;
			_count++;
		}
		//---------------------------------------------------------------------
		public bool Remove(T value)
		{
			int index = this.IndexOf(value);

			if (index < 0) return false;

			this.RemoveAt(index);

			return true;
		}
		//---------------------------------------------------------------------
		public void RemoveAt(int index)
		{
			ListItem<T> current = this.GetItemInternal(index);

			if (current == null) return;

			if (current.Previous == null)
				current.Next.Previous = null;
			else
			{
				current.Previous.Next = current.Next;

				if (current.Next != null)
					current.Next.Previous = current.Previous;
			}

			if (current == _first) _first = current.Next;
			if (current == _last)  _last  = current.Previous;

			_count--;
		}
		//---------------------------------------------------------------------
		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
		//---------------------------------------------------------------------
		private ListItem<T> GetItemInternal(int index)
		{
			if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException(nameof(index));

			ListItem<T> current = _first;

			for (int i = 0; i < index; ++i)
			{
				if (current?.Next == null) return null;
				current = current.Next;
			}

			return current;
		}
	}
}