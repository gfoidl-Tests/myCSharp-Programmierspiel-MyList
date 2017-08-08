//#define ELEPHANT

using System;
using System.Collections;
using System.Collections.Generic;

namespace Inflames2K
{
    public class MyList<T> : IList<T>
    {
        private ListItem<T> _head;
        private ListItem<T> _tail;
        private int         _count;
        //---------------------------------------------------------------------
        public MyList()
        {
            _head = new ListItem<T>(default(T));
            _tail = new ListItem<T>(default(T));

            this.Clear();
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
        public void Add(T value) => this.InsertInternal(value, _tail);
        //---------------------------------------------------------------------
        public void Clear()
        {
            _head.Next     = _tail;
            _tail.Previous = _head;
            _count         = 0;
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
        public int IndexOf(T item) => this.GetItemInternal(item).Index;
        //---------------------------------------------------------------------
        public void Insert(int index, T value)
        {
            ListItem<T> rightElement = null;

            if (index == _count)
                rightElement = _tail;
            else
                rightElement = this.GetItemInternal(index);

            this.InsertInternal(value, rightElement);
        }
        //---------------------------------------------------------------------
        public bool Remove(T value)
        {
            ListItem<T> item = this.GetItemInternal(value).Item;
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
        #region Private Members
        private void InsertInternal(T value, ListItem<T> rightElement)
        {
            // null as value is allowed -> consumer has to handle this
            ListItem<T> toInsert = new ListItem<T>(value);

            toInsert.Previous          = rightElement.Previous;
            toInsert.Next              = rightElement;
            rightElement.Previous.Next = toInsert;
            rightElement.Previous      = toInsert;

            _count++;
        }
        //---------------------------------------------------------------------
        private ListItem<T> GetItemInternal(int index)
        {
            if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException(nameof(index));

            ListItem<T> current = null;

            if (index < _count / 2)
            {
                current = _head.Next;

                for (int i = 0; i < index; ++i)
                    current = current.Next;
            }
            else
            {
                current = _tail.Previous;

                for (int i = _count - 1; i > index; --i)
                    current = current.Previous;
            }

            return current;
        }
        //---------------------------------------------------------------------
        private (ListItem<T> Item, int Index) GetItemInternal(T item)
        {
            ListItem<T> current = _head.Next;
            int index           = 0;
#if ELEPHANT
            T tailValue         = _tail.Value;
            _tail.Value         = item;

            while (true)
            {
                if (object.Equals(current.Value, item)) break;
                index++;
                current = current.Next;
            }

            _tail.Value = tailValue;

            if (current != _tail)
                return (current, index);
#else
            for (; current != _tail; current = current.Next, ++index)
                if (object.Equals(current.Value, item))
                    return (current, index);
#endif
            return (null as ListItem<T>, -1);
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
        #endregion
    }
}