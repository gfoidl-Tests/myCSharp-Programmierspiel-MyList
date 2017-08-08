using System.Linq;
using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class GetEnumerator
    {
        [Test]
        public void Correct_elements_returned()
        {
            var sut = new MyList<int>();
            sut.Add(4);
            sut.Add(1);
            sut.Add(2);

            Assume.That(sut.Count, Is.EqualTo(3));

            int[] expected = { 4, 1, 2 };
            int[] actual = sut.AsEnumerable().ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void No_elements___returns_empty_list()
        {
            var sut = new MyList<int>();

            Assume.That(sut.Count, Is.EqualTo(0));

            int[] actual = sut.AsEnumerable().ToArray();

            Assert.AreEqual(0, actual.Length);
        }
    }
}