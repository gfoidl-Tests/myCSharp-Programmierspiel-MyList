using System;
using NUnit.Framework;

namespace Inflames2K.Tests.MyListEnumeratorTests
{
	[TestFixture]
	public class Ctor
	{
		[Test]
		public void First_is_null___throws_ArgumentNull()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				var sut = new MyListEnumerator<object>(null);
			});
		}
		//---------------------------------------------------------------------
		[Test]
		public void First_given___Current_is_null()
		{
			ListItem<object> first 		 = new ListItem<object>(new object());
			MyListEnumerator<object> sut = new MyListEnumerator<object>(first);

			Assert.IsNull(sut.Current);
		}
	}
}