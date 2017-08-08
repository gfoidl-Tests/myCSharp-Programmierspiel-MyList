using NUnit.Framework;

namespace Inflames2K.Tests.ListItemTests
{
    [TestFixture]
    public class Ctor
    {
        [Test]
        public void Value_given___Value_set()
        {
            ListItem<int> sut = new ListItem<int>(42);

            Assert.AreEqual(42, sut.Value);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Null_given_as_value___Value_set()
        {
            ListItem<object> sut = new ListItem<object>(null);

            Assert.IsNull(sut.Value);
        }
    }
}