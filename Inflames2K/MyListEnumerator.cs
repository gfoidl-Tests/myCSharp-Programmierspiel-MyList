using System.Collections;
using System.Collections.Generic;

namespace Inflames2K
{
	internal class MyListEnumerator<T> : IEnumerator<T>
	{
		private ListItem<T> _first;
		private ListItem<T> _current;
		//---------------------------------------------------------------------
		public MyListEnumerator(ListItem<T> first)
		{
			if (first == null) throw new System.ArgumentNullException(nameof(first));

			_first = first;
		}
		//---------------------------------------------------------------------
		public T Current 		   { get { return _current != null ? _current.Value : default(T); } }
		object IEnumerator.Current { get { return this.Current; } }
		//---------------------------------------------------------------------
		public bool MoveNext()
		{
			if (_current == null)
			{
				_current = _first;
				return true;
			}

			if (_current.Next == null) return false;

			_current = _current.Next;

			return true;
		}
		//---------------------------------------------------------------------
		public void Reset()
		{
			_current = null;
		}
		//---------------------------------------------------------------------
		public void Dispose()
		{
			// nothing to do
		}
	}
}