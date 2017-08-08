#include "stdafx.h"

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Remove)
    {
    public:
        TEST_METHOD(Empty_list___nothing_happens)
        {
            MyList<int> sut;

            bool actual = sut.Remove(42);

            Assert::IsFalse(actual);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Item_contained___item_removed_and_true_returned)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            bool actual = sut.Remove(2);

            Assert::IsTrue(actual);
            Assert::AreEqual(2u, sut.Count());
            Assert::AreEqual(1, sut.getItem(0));
            Assert::AreEqual(3, sut.getItem(1));
        }
        //---------------------------------------------------------------------
        TEST_METHOD(First_element_removed___item_removed_and_true_returned)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            bool actual = sut.Remove(1);

            Assert::IsTrue(actual);
            Assert::AreEqual(2u, sut.Count());
            Assert::AreEqual(2, sut.getItem(0));
            Assert::AreEqual(3, sut.getItem(1));
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Last_element_removed___item_removed_and_true_returned)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            bool actual = sut.Remove(3);

            Assert::IsTrue(actual);
            Assert::AreEqual(2u, sut.Count());
            Assert::AreEqual(1, sut.getItem(0));
            Assert::AreEqual(2, sut.getItem(1));
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Item_not_contained___returns_false)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);

            bool actual = sut.Remove(42);

            Assert::IsFalse(actual);
        }
    };
}