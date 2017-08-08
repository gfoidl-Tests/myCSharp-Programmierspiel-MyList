#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(ListItem_Ctor)
    {
    public:
        TEST_METHOD(Value_given___Value_set)
        {
            ListItem<int> sut(42);

            Assert::AreEqual(42, sut.Value);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Value_given___Next_and_Previous_are_NULL)
        {
            ListItem<int> sut(42);

            Assert::IsNull(sut.Next);
            Assert::IsNull(sut.Previous);
        }
    };
}