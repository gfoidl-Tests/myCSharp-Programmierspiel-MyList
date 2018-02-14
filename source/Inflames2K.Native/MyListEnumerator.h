#pragma once

#include <stdexcept>
#include "ListItem.h"

namespace Inflames2K
{
    template<typename T>
    class MyListEnumerator
    {
    public:
        MyListEnumerator(ListItem<T>* first, ListItem<T>* tail);
        
        T    Current();
        bool MoveNext();
        void Reset();
    //-------------------------------------------------------------------------
    private:
        ListItem<T>* _first;
        ListItem<T>* _current;
        ListItem<T>* _tail;
    };
    //-------------------------------------------------------------------------
    template<typename T>
    MyListEnumerator<T>::MyListEnumerator(ListItem<T>* first, ListItem<T>* tail)
    {
        if (first == nullptr) throw std::invalid_argument("First must not be null");

        _first   = first;
        _current = nullptr;
        _tail    = tail;
    }
    //-------------------------------------------------------------------------
    template<typename T>
    T MyListEnumerator<T>::Current()
    {
        return _current != nullptr ? _current->Value : T();
    }
    //-------------------------------------------------------------------------
    template<typename T>
    bool MyListEnumerator<T>::MoveNext()
    {
        if (_first == _tail) return false;

        if (_current == nullptr)
        {
            _current = _first;
            return true;
        }

        if (_current->Next == _tail) return false;

        _current = _current->Next;

        return true;
    }
    //-------------------------------------------------------------------------
    template<typename T>
    void MyListEnumerator<T>::Reset()
    {
        _current = nullptr;
    }
}
