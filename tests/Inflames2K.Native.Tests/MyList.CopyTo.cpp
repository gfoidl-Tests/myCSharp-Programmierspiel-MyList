#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_CopyTo)
    {
    public:
        TEST_METHOD(Empty_list___nothing_copied)
        {
            const int N = 100;
            MyList<int> sut;
            int arr[N];

            for (int i = 0; i < N; ++i)
                arr[i] = 42;

            sut.CopyTo(arr, 0);

            for (int i = 0; i < N; ++i)
                Assert::AreEqual(42, arr[i]);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(List_with_two_elements___elements_copied_in_order)
        {
            MyList<int> sut;
            sut.Add(2);
            sut.Add(1);

            Assert::AreEqual(2u, sut.Count());

            const int N = 100;
            int arr[N];

            for (int i = 0; i < N; ++i)
                arr[i] = 42;

            sut.CopyTo(arr, 0);

            Assert::AreEqual(2, arr[0]);
            Assert::AreEqual(1, arr[1]);

            for (int i = 2; i < N; ++i)
                Assert::AreEqual(42, arr[i]);
        }
    };
}
