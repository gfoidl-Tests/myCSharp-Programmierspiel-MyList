using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class Contains
    {
        [Test]
        public void Empty_list___returns_false()
        {
            var sut = new MyList<int>();

            bool actual = sut.Contains(42);

            Assert.IsFalse(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Item_is_contained___returns_true([Values(1, 2)] int value)
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);

            Assume.That(sut.Count, Is.EqualTo(2));

            bool actual = sut.Contains(value);

            Assert.IsTrue(actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Item_is_not_contained___returns_false([Values(0, -1, int.MinValue, int.MaxValue, 42)]int value)
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);

            Assume.That(sut.Count, Is.EqualTo(2));

            bool actual = sut.Contains(value);

            Assert.IsFalse(actual);
        }
    }
}