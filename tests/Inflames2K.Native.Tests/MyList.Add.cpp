#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Add)
    {
    public:
        TEST_METHOD(Count_increased_by_one)
        {
            MyList<object> sut;

            Assert::AreEqual(0u, sut.Count());

            sut.Add(object());

            Assert::AreEqual(1u, sut.Count());
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Two_items_added___Retrieving_via_indexer_OK)
        {
            MyList<int> sut;

            sut.Add(1);
            sut.Add(2);

            Assert::AreEqual(2u, sut.Count());
            Assert::AreEqual(1, sut.getItem(0));
            Assert::AreEqual(2, sut.getItem(1));
        }
    //-------------------------------------------------------------------------
    private:
        struct object {};
    };
}
