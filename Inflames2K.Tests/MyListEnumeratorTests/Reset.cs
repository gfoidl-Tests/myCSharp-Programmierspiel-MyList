using NUnit.Framework;

namespace Inflames2K.Tests.MyListEnumeratorTests
{
	[TestFixture]
	public class Reset
	{
		[Test]
		public void Current_is_null()
		{
			ListItem<object> first 		 = new ListItem<object>(new object());
			ListItem<object> second 	 = new ListItem<object>(new object());
			first.Next 					 = second;
			second.Previous 			 = first;
			MyListEnumerator<object> sut = new MyListEnumerator<object>(first);

			Assume.That(sut.MoveNext(), Is.True);
			Assume.That(sut.Current, Is.EqualTo(first.Value));

			sut.Reset();
			Assert.IsNull(sut.Current);
		}
	}
}