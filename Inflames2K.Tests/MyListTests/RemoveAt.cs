using System;
using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
	[TestFixture]
	public class RemoveAt
	{
		[Test]
		public void Negative_index___throws_ArgumentOutOfRange()
		{
			var sut = new MyList<int>();

			Assume.That(sut.Count, Is.EqualTo(0));

			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				sut.RemoveAt(-1);
			});
		}
		//---------------------------------------------------------------------
		[Test]
		public void First_element_removed___OK()
		{
			var sut = new MyList<int>();
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			Assume.That(sut.Count, Is.EqualTo(3));

			sut.RemoveAt(0);

			Assert.AreEqual(2, sut.Count);
			Assert.AreEqual(2, sut[0]);
			Assert.AreEqual(3, sut[1]);
		}
		//---------------------------------------------------------------------
		[Test]
		public void Last_element_removed___OK()
		{
			var sut = new MyList<int>();
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			Assume.That(sut.Count, Is.EqualTo(3));

			sut.RemoveAt(2);

			Assert.AreEqual(2, sut.Count);
			Assert.AreEqual(1, sut[0]);
			Assert.AreEqual(2, sut[1]);
		}
		//---------------------------------------------------------------------
		[Test]
		public void Element_removed___OK()
		{
			var sut = new MyList<int>();
			sut.Add(1);
			sut.Add(2);
			sut.Add(3);

			Assume.That(sut.Count, Is.EqualTo(3));

			sut.RemoveAt(1);

			Assert.AreEqual(2, sut.Count);
			Assert.AreEqual(1, sut[0]);
			Assert.AreEqual(3, sut[1]);
		}
	}
}