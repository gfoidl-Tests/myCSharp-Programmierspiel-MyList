#include "stdafx.h"

namespace Inflames2KNativeTests
{
	TEST_CLASS(MyList_GetEnumerator)
	{
	public:
		TEST_METHOD(Correct_elements_returned)
		{
			MyList<int> sut;
			sut.Add(4);
			sut.Add(1);
			sut.Add(2);

			Assert::AreEqual(3u, sut.Count);

			auto it = sut.GetEnumerator();

			it->MoveNext();
			Assert::AreEqual(4, it->Current());

			it->MoveNext();
			Assert::AreEqual(1, it->Current());

			it->MoveNext();
			Assert::AreEqual(2, it->Current());

			bool actual = it->MoveNext();

			Assert::IsFalse(actual);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(No_elements___returns_empty_list)
		{
			MyList<int> sut;

			Assert::AreEqual(0u, sut.Count);

			auto it = sut.GetEnumerator();

			bool actual = it->MoveNext();
			
			Assert::IsFalse(actual);
		}
	};
}