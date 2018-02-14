#include <iostream>
#include "MyList.h"

using namespace std;
using namespace Inflames2K;

int main()
{
    MyList<int> list;

    list.Add(3);
    list.Add(4);
    list.Add(1);

    cout << endl;
    cout << list[0] << endl;
    cout << list[1] << endl;
    cout << list[2] << endl;

    cout << endl;

    auto enumerator = list.GetEnumerator();
    while (enumerator->MoveNext())
        cout << enumerator->Current() << endl;

    cout << endl;

    list.Clear();
    list.Add(42);
    list.Add(666);

    enumerator = list.GetEnumerator();
    while (enumerator->MoveNext())
        cout << enumerator->Current() << endl;

    cout << endl;

    list.setItem(1, 3);

    enumerator = list.GetEnumerator();
    while (enumerator->MoveNext())
        cout << enumerator->Current() << endl;
}
