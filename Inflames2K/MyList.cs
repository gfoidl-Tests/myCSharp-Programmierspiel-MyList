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
			_last  = null;
			_count = 0;
		}
		//---------------------------------------------------------------------
		public bool Contains(T item) => this.IndexOf(item) >= 0;
		//---------------------------------------------------------------------
		public void CopyTo(T[] array, int arrayIndex)
		{
			for (var current = _first; current != null; current = current.Next)
				array[arrayIndex++] = current.Value;
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
				if (object.Equals(current.Value, item)) return index;
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
			ListItem<T> item = this.GetItemInternal(value);
			return this.RemoveInternal(item);
		}
		//---------------------------------------------------------------------
		public void RemoveAt(int index)
		{
			ListItem<T> item = this.GetItemInternal(index);
			this.RemoveInternal(item);
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
		//---------------------------------------------------------------------
		private ListItem<T> GetItemInternal(T item)
		{
			for (ListItem<T> current = _first; current != null; current = current.Next)
				if (object.Equals(current.Value, item)) return current;

			return null;
		}
		//---------------------------------------------------------------------
		private bool RemoveInternal(ListItem<T> item)
		{
			if (item == null) return false;

			if (item.Previous == null)
				item.Next.Previous = null;
			else
			{
				item.Previous.Next = item.Next;

				if (item.Next != null)
					item.Next.Previous = item.Previous;
			}

			if (item == _first) _first = item.Next;
			if (item == _last)  _last  = item.Previous;

			_count--;

			return true;
		}
	}
}