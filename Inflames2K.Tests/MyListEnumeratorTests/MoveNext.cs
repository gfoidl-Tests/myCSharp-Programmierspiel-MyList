using NUnit.Framework;

namespace Inflames2K.Tests.MyListEnumeratorTests
{
	[TestFixture]
	public class MoveNext
	{
		[Test]
		public void First_call_to_MoveNext___Current_set_to_first_element()
		{
			ListItem<object> first 		 = new ListItem<object>(new object());
			ListItem<object> second 	 = new ListItem<object>(new object());
			first.Next 					 = second;
			second.Previous 			 = first;
			MyListEnumerator<object> sut = new MyListEnumerator<object>(first);

			Assume.That(sut.Current, Is.Null);
			Assume.That(sut.MoveNext(), Is.True);

			Assert.AreEqual(first.Value, sut.Current);
		}
		//---------------------------------------------------------------------
		[Test]
		public void Two_calls___Current_ist_second_element()
		{
			ListItem<object> first 		 = new ListItem<object>(new object());
			ListItem<object> second 	 = new ListItem<object>(new object());
			first.Next 					 = second;
			second.Previous 			 = first;
			MyListEnumerator<object> sut = new MyListEnumerator<object>(first);

			Assume.That(sut.Current, Is.Null);
			Assume.That(sut.MoveNext(), Is.True);
			Assume.That(sut.MoveNext(), Is.True);

			Assert.AreEqual(second.Value, sut.Current);

		}
		//---------------------------------------------------------------------
		[Test]
		public void Three_calls_with_two_elements___Returns_false()
		{
			ListItem<object> first 		 = new ListItem<object>(new object());
			ListItem<object> second 	 = new ListItem<object>(new object());
			first.Next 					 = second;
			second.Previous 			 = first;
			MyListEnumerator<object> sut = new MyListEnumerator<object>(first);

			Assume.That(sut.Current, Is.Null);
			Assume.That(sut.MoveNext(), Is.True);
			Assume.That(sut.MoveNext(), Is.True);

			Assert.IsFalse(sut.MoveNext());
		}
	}
}