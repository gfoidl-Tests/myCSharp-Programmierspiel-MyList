#include "stdafx.h"

namespace Inflames2KNativeTests
{
	TEST_CLASS(MyList_IndexOf)
	{
	public:
		TEST_METHOD(Empty_list___returns_minus_1)
		{
			MyList<int> sut;

			int actual = sut.IndexOf(42);

			Assert::AreEqual(-1, actual);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Item_is_contained___returns_index)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);

			int actual = sut.IndexOf(1);

			Assert::AreEqual(1, actual);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Item_is_contained_in_lower_half___returns_index)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);
			sut.Add(3);
			sut.Add(4);
			sut.Add(5);

			int actual = sut.IndexOf(1);

			Assert::AreEqual(1, actual);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Item_is_contained_in_upper_half___returns_index)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);
			sut.Add(3);
			sut.Add(4);
			sut.Add(5);

			int actual = sut.IndexOf(4);

			Assert::AreEqual(3, actual);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Item_is_not_contained___returns_minus_1)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);

			int actual = sut.IndexOf(42);

			Assert::AreEqual(-1, actual);
		}
	};
}