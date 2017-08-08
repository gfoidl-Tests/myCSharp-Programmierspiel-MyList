#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Ctor)
    {
    public:
        TEST_METHOD(Count_is_0)
        {
            MyList<object> sut;

            Assert::AreEqual(0u, sut.Count());
        }
        //---------------------------------------------------------------------
        TEST_METHOD(IsReadOnly_is_false)
        {
            MyList<object> sut;

            Assert::IsFalse(sut.IsReadOnly());
        }
    //-------------------------------------------------------------------------
    private:
        struct object {};
    };
}