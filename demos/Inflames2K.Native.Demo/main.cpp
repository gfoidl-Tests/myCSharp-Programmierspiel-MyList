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

	auto enumerator = list.GetEnumerator();
	while (enumerator->MoveNext())
	{
		cout << enumerator->Current() << endl;
	}
	delete enumerator;

	list.Clear();
	list.Add(42);
	list.Add(666);

	enumerator = list.GetEnumerator();
	while (enumerator->MoveNext())
	{
		cout << enumerator->Current() << endl;
	}
	delete enumerator;
}