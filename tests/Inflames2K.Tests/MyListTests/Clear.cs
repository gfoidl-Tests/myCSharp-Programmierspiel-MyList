using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Count_is_null()
        {
            var sut = new MyList<int>();
            sut.Add(1);
            sut.Add(2);

            Assume.That(sut.Count, Is.EqualTo(2));

            sut.Clear();

            Assert.AreEqual(0, sut.Count);
        }
    }
}