#include "stdafx.h"

namespace Inflames2KNativeTests
{
	TEST_CLASS(MyList_RemoveAt)
	{
	public:
		TEST_METHOD(Negative_index___throws_ArgumentOutOfRange)
		{
			MyList<int> sut;
			bool isExceptionThrown = false;

			try
			{
				sut.RemoveAt(-1);
			}
			catch (std::invalid_argument&)
			{
				isExceptionThrown = true;
			}

			Assert::IsTrue(isExceptionThrown);
		}
		//---------------------------------------------------------------------
		TEST_METHOD(First_element_removed___OK)
		{
			MyList<int> sut;
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			sut.RemoveAt(0);

			Assert::AreEqual(2u, sut.Count);
			Assert::AreEqual(2, sut.getItem(0));
			Assert::AreEqual(3, sut.getItem(1));
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Last_element_removed___OK)
		{
			MyList<int> sut;
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			sut.RemoveAt(2);

			Assert::AreEqual(2u, sut.Count);
			Assert::AreEqual(1, sut.getItem(0));
			Assert::AreEqual(2, sut.getItem(1));
		}
		//---------------------------------------------------------------------
		TEST_METHOD(Element_removed___OK)
		{
			MyList<int> sut;
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			sut.RemoveAt(1);

			Assert::AreEqual(2u, sut.Count);
			Assert::AreEqual(1, sut.getItem(0));
			Assert::AreEqual(3, sut.getItem(1));
		}
	};
}