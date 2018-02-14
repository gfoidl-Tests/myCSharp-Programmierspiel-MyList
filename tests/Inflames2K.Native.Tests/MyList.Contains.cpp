#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Contains)
    {
    public:
        TEST_METHOD(Empty_list___returns_false)
        {
            MyList<int> sut;

            bool actual = sut.Contains(42);

            Assert::IsFalse(actual);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Item_is_contained___returns_true)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);

            Assert::AreEqual(2u, sut.Count());

            bool actual = sut.Contains(1);

            Assert::IsTrue(actual);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Item_is_not_contained___returns_false)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);

            Assert::AreEqual(2u, sut.Count());

            bool actual = sut.Contains(-1);

            Assert::IsFalse(actual);
        }
    };
}
