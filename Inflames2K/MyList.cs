using System;
using System.Collections;
using System.Collections.Generic;

namespace Inflames2K
{
	public class MyList<T> : IList<T>
	{
		private ListItem<T> _head;
		private ListItem<T> _tail;
		private int 		_count;
		//---------------------------------------------------------------------
		public MyList()
		{
			_head = new ListItem<T>(default(T));
			_tail = new ListItem<T>(default(T));

			_head.Next 	   = _tail;
			_tail.Previous = _head;
			_count 		   = 0;
		}
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

			item.Previous 		= _tail.Previous;
			item.Next 			= _tail;
			_tail.Previous.Next = item;
			_tail.Previous 		= item;

			_count++;
		}
		//---------------------------------------------------------------------
		public void Clear()
		{
			_head.Next 	   = _tail;
			_tail.Previous = _head;
			_count 		   = 0;
		}
		//---------------------------------------------------------------------
		public bool Contains(T item) => this.IndexOf(item) >= 0;
		//---------------------------------------------------------------------
		public void CopyTo(T[] array, int arrayIndex)
		{
			for (var current = _head.Next; current != _tail; current = current.Next)
				array[arrayIndex++] = current.Value;
		}
		//---------------------------------------------------------------------
		public IEnumerator<T> GetEnumerator()
		{
			for (var current = _head.Next; current != _tail; current = current.Next)
				yield return current.Value;
		}
		//---------------------------------------------------------------------
		public int IndexOf(T item)
		{
			ListItem<T> current = _head.Next;
			int index 			= 0;

			while (current != _tail)
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

			ListItem<T> current = _head.Next;

			for (int i = 0; i < index; ++i)
			{
				if (current?.Next == _tail) return null;
				current = current.Next;
			}

			return current;
		}
		//---------------------------------------------------------------------
		private ListItem<T> GetItemInternal(T item)
		{
			for (ListItem<T> current = _head.Next; current != _tail; current = current.Next)
				if (object.Equals(current.Value, item)) return current;

			return null;
		}
		//---------------------------------------------------------------------
		private bool RemoveInternal(ListItem<T> item)
		{
			if (item == null) return false;

			item.Previous.Next = item.Next;
			item.Next.Previous = item.Previous;
			_count--;

			return true;
		}
	}
}