using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
	[TestFixture]
	public class Ctor
	{
		[Test]
		public void Count_is_0()
		{
			MyList<object> sut = new MyList<object>();

			Assert.AreEqual(0, sut.Count);
		}
		//---------------------------------------------------------------------
		[Test]
		public void IsReadOnly_is_false()
		{
			MyList<object> sut = new MyList<object>();

			Assert.IsFalse(sut.IsReadOnly);
		}
	}
}