#pragma once

#include <stdexcept>
#include "ListItem.h"
#include "Tuple.h"
#include "MyListEnumerator.h"

namespace Inflames2K
{
	typedef unsigned int uint;
	//-------------------------------------------------------------------------
	template<typename T>
	class MyList
	{
	public:
		MyList();
		~MyList();
		T getItem(uint index);
		void setItem(uint index, T value);
		uint Count() { return _count; }
		bool IsReadOnly() { return false; }
		void Add(const T& value) { this->InsertInternal(value, _tail); }
		void Clear();
		bool Contains(T item) { this->IndexOf(item) >= 0; }
		void CopyTo(T* array, uint arrayIndex);
		MyListEnumerator<T>* GetEnumerator();
		int IndexOf(T item) { (this->GetItemInternal(item))->Item2; }
		void Insert(uint index, T item);
		bool Remove(T item);
		void RemoveAt(uint index);
	//-------------------------------------------------------------------------
	private:
		ListItem<T>* _head;
		ListItem<T>* _tail;
		uint _count;

		void InsertInternal(const T& value, ListItem<T>* rightElement);
		ListItem<T>& GetItemInternal(uint index);
		Tuple<ListItem<T>&, uint>* GetItemInternal(T item);
		bool RemoveInternal(ListItem<T>* item);
	};
	//-------------------------------------------------------------------------
	template<typename T>
	MyList<T>::MyList()
	{
		_head = new ListItem<T>(NULL);
		_tail = new ListItem<T>(NULL);

		this->Clear();
	}
	//-------------------------------------------------------------------------
	template<typename T>
	MyList<T>::~MyList()
	{
		this->Clear();

		delete _head;
		delete _tail;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	T MyList<T>::getItem(uint index)
	{
		ListItem<T>& item = this->GetItemInternal(index);

		return item.Value;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::setItem(uint index, T value)
	{
		ListItem<T>& item = this.GetItemInternal(index);

		item.Value = value;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::Clear()
	{
		ListItem<T>* current = _head->Next;

		while (current != NULL && current->Next != NULL)
		{
			ListItem<T>* next = current->Next;
			delete current;
			current = next;
		}

		_head->Next = _tail;
		_tail->Previous = _head;
		_count = 0;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	MyListEnumerator<T>* MyList<T>::GetEnumerator()
	{
		return new MyListEnumerator<T>(_head->Next, _tail);
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::CopyTo(T* array, uint arrayIndex)
	{
		for (ListItem<T>& current = _head.Next; current != _tail; current = current.Next)
			array[arrayIndex++] = current.Value;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::Insert(uint index, T item)
	{
		ListItem<T>* rightElement = NULL;

		if (index == _count)
			rightElement = _tail;
		else
			rightElement = this->GetItemInternal(index);

		this->InsertInternal(item, rightElement);
	}
	//-------------------------------------------------------------------------
	template<typename T>
	bool MyList<T>::Remove(T value)
	{
		ListItem<T>& item = (this->GetItemInternal(value)).Item1;

		return this->RemoveInternal(item);
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::RemoveAt(uint index)
	{
		ListItem<T>& item = this->GetItemInternal(index);

		this->RemoveInternal(item);
	}
	//-------------------------------------------------------------------------
	template<typename T>
	void MyList<T>::InsertInternal(const T& value, ListItem<T>* rightElement)
	{
		ListItem<T>* toInsert = new ListItem<T>(value);

		toInsert->Previous = rightElement->Previous;
		toInsert->Next = rightElement;
		rightElement->Previous->Next = toInsert;
		rightElement->Previous = toInsert;

		_count++;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	ListItem<T>& MyList<T>::GetItemInternal(uint index)
	{
		if (index >= _count) throw std::invalid_argument("Index out of range");

		ListItem<T>& current = NULL;

		if (index < _count / 2)
		{
			current = _head->Next;

			for (uint i = 0; i < index; ++i)
				current = current.Next;
		}
		else
		{
			current = _tail->Previous;

			for (uint i = _count - 1; i > index; --i)
				current = current.Previous;
		}

		return current;
	}
	//-------------------------------------------------------------------------
	template<typename T>
	Tuple<ListItem<T>&, uint>* MyList<T>::GetItemInternal(T item)
	{
		ListItem<T>& current = _head.Next;
		int index = 0;

		for (; current != _tail; current = current.Next, ++index)
			if (current.Value == item)
				return new Tuple<ListItem<T>, uint>(current, index);

		return new Tuple<ListItem<T>, uint>(NULL, -1);
	}
	//-------------------------------------------------------------------------
	template<typename T>
	bool MyList<T>::RemoveInternal(ListItem<T>* item)
	{
		if (item == NULL) return false;

		item->Previous.Next = item->Next;
		item->Next.Previous = item->Previous;
		_count--;

		delete item;

		return true;
	}
}