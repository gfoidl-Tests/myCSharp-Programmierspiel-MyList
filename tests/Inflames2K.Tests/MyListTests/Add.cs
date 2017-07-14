using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
	[TestFixture]
	public class Add
	{
		[Test]
		public void Count_increased_by_one()
		{
			var sut = new MyList<object>();

			Assume.That(sut.Count, Is.EqualTo(0));

			sut.Add(new object());

			Assert.AreEqual(1, sut.Count);
		}
		//---------------------------------------------------------------------
		[Test]
		public void Null_added___OK()
		{
			var sut = new MyList<object>();

			sut.Add(null);
		}
		//---------------------------------------------------------------------
		[Test]
		public void Two_items_added___Retrieving_via_indexer_OK()
		{
			var sut = new MyList<int>();
			sut.Add(1);
			sut.Add(2);

			Assert.AreEqual(2, sut.Count);
			Assert.AreEqual(1, sut[0]);
			Assert.AreEqual(2, sut[1]);
		}
	}
}