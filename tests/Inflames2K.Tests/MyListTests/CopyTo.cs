using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class CopyTo
    {
        [Test]
        public void Empty_list___nothing_copied()
        {
            var sut     = new MyList<int>();
            int[] array = new int[100];

            sut.CopyTo(array, 0);

            CollectionAssert.AreEqual(new int[100], array);
        }
        //---------------------------------------------------------------------
        [Test]
        public void List_with_two_elements___elements_copied_in_order()
        {
            var sut = new MyList<int>();
            sut.Add(2);
            sut.Add(1);

            Assume.That(sut.Count, Is.EqualTo(2));

            int[] array = new int[100];

            sut.CopyTo(array, 0);

            int[] expected = new int[100];
            expected[0] = 2;
            expected[1] = 1;

            CollectionAssert.AreEqual(expected, array);
        }
    }
}