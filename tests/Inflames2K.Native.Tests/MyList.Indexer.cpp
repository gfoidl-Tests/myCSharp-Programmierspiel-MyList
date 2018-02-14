#include "stdafx.h"
#include <stdexcept>

namespace Inflames2KNativeTests
{
    TEST_CLASS(MyList_Indexer)
    {
    public:
        TEST_METHOD(Get_on_new_list___throws_Invalid_Argument)
        {
            MyList<int> sut;
            bool isExceptionThrown = false;

            try
            {
                int actual = sut.getItem(0);
            }
            catch (std::invalid_argument&)
            {
                isExceptionThrown = true;
            }

            Assert::IsTrue(isExceptionThrown);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Get_0___returns_first_element)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            int actual = sut[0];

            Assert::AreEqual(1, actual);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Get_1___returns_second_element)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            int actual = sut.getItem(1);

            Assert::AreEqual(2, actual);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Get_3___throws_ArgumentOutOfRange)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            bool isExceptionThrown = false;

            try
            {
                int actual = sut.getItem(3);
            }
            catch (std::invalid_argument&)
            {
                isExceptionThrown = true;
            }

            Assert::IsTrue(isExceptionThrown);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Set_on_new_list___throws_ArgumentOutOfRange)
        {
            MyList<int> sut;
            bool isExceptionThrown = false;

            try
            {
                sut.setItem(0, 42);
            }
            catch (std::invalid_argument&)
            {
                isExceptionThrown = true;
            }

            Assert::IsTrue(isExceptionThrown);
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Set_0___first_element_changed)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            sut.setItem(0, 42);

            Assert::AreEqual(42, sut.getItem(0));
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Set_1___second_element_changed)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            sut.setItem(1, 42);

            Assert::AreEqual(42, sut.getItem(1));
        }
        //---------------------------------------------------------------------
        TEST_METHOD(Set_3___throws_ArgumentOutOfRange)
        {
            MyList<int> sut;
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            bool isExceptionThrown = false;

            try
            {
                sut.setItem(3, 42);
            }
            catch (std::invalid_argument&)
            {
                isExceptionThrown = true;
            }

            Assert::IsTrue(isExceptionThrown);
        }
    };
}
