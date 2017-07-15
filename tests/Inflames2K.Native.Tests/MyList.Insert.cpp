#include "stdafx.h"

namespace Inflames2KNativeTests
{
	TEST_CLASS(MyList_Insert)
	{
	public:
		TEST_METHOD(Empty_list_index_0___element_added)
		{
			MyList<int> sut;

			sut.Insert(0, 42);

			Assert::AreEqual(1u, sut.Count);
			Assert::AreEqual(42, sut.getItem(0));
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Empty_list_index_not_equal_0___throws_ArgumentOutOfRange)
		{
			MyList<int> sut;
			bool isExceptionThrown = false;

			try
			{
				sut.Insert(1, 42);
			}
			catch (std::invalid_argument&)
			{
				isExceptionThrown = true;
			}

			Assert::IsTrue(isExceptionThrown);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(List_with_two_elements_and_insert_in_between___OK)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);

			sut.Insert(1, 42);

			Assert::AreEqual(3u, sut.Count);
			Assert::AreEqual(2, sut.getItem(0));
			Assert::AreEqual(42, sut.getItem(1));
			Assert::AreEqual(1, sut.getItem(2));
		}
		//---------------------------------------------------------------------
		TEST_METHOD(List_with_two_elements_and_insert_at_end___OK)
		{
			MyList<int> sut;
			sut.Add(2);
			sut.Add(1);

			sut.Insert(2, 42);

			Assert::AreEqual(3u, sut.Count);
			Assert::AreEqual(2, sut.getItem(0));
			Assert::AreEqual(1, sut.getItem(1));
			Assert::AreEqual(42, sut.getItem(2));
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Issue_3_Insert_two_elements___OK)
		{
			MyList<int> sut;
			sut.Add(1);

			sut.Insert(0, 40);
			sut.Insert(0, 41);

			Assert::AreEqual(3u, sut.Count);
			Assert::AreEqual(41, sut[0]);
			Assert::AreEqual(40, sut[1]);
			Assert::AreEqual(1, sut[2]);
		}
	};
}