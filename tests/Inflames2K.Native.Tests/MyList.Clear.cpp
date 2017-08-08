#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Clear)
    {
    public:
        TEST_METHOD(Count_is_null)
        {
            MyList<int> sut;

            sut.Add(1);
            sut.Add(2);

            Assert::AreEqual(2u, sut.Count());

            sut.Clear();

            Assert::AreEqual(0u, sut.Count());
        }
    };
}