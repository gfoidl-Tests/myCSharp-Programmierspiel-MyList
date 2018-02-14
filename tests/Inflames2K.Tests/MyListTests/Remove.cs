using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Empty_list___nothing_happens()
        {
            var sut = new MyList<int>();

            Assume.That(sut.Count, Is.EqualTo(0));

            bool actual = sut.Remove(42);

            Assert.IsFalse(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Item_contained___item_removed_and_true_returned()
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            bool actual = sut.Remove(2);

            Assert.IsTrue(actual);
            Assert.AreEqual(2, sut.Count);
            Assert.AreEqual(1, sut[0]);
            Assert.AreEqual(3, sut[1]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void First_element_removed___item_removed_and_true_returned()
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            bool actual = sut.Remove(1);

            Assert.IsTrue(actual);
            Assert.AreEqual(2, sut.Count);
            Assert.AreEqual(2, sut[0]);
            Assert.AreEqual(3, sut[1]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Last_element_removed___item_removed_and_true_returned()
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            bool actual = sut.Remove(3);

            Assert.IsTrue(actual);
            Assert.AreEqual(2, sut.Count);
            Assert.AreEqual(1, sut[0]);
            Assert.AreEqual(2, sut[1]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Item_not_contained___returns_false()
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);

            Assume.That(sut.Count, Is.EqualTo(2));

            bool actual = sut.Remove(42);

            Assert.IsFalse(actual);
        }
    }
}
