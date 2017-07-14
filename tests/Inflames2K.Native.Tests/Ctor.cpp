#include "stdafx.h"

namespace Inflames2KNativeTests
{
	TEST_CLASS(Ctor)
	{
	public:
		TEST_METHOD(Value_given___Value_set)
		{
			ListItem<int> sut(42);

			Assert::AreEqual(42, sut.Value);
		}
	};
}