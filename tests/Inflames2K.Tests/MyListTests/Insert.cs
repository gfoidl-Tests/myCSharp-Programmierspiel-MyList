using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class Insert
    {
        [Test]
        public void Empty_list_index_0___element_added()
        {
            var sut = new MyList<int>();

            Assume.That(sut.Count, Is.EqualTo(0));

            sut.Insert(0, 42);

            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual(42, sut[0]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Empty_list_index_not_equal_0___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut.Insert(1, 42);
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void List_with_two_elements_and_insert_in_between___OK()
        {
            var sut = new MyList<int>();

            sut.Add(2);
            sut.Add(1);

            Assume.That(sut.Count, Is.EqualTo(2));

            sut.Insert(1, 42);

            Assert.AreEqual(3, sut.Count);
            Assert.AreEqual(2, sut[0]);
            Assert.AreEqual(42, sut[1]);
            Assert.AreEqual(1, sut[2]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void List_with_two_elements_and_insert_at_end___OK()
        {
            var sut = new MyList<int>();

            sut.Add(2);
            sut.Add(1);

            Assume.That(sut.Count, Is.EqualTo(2));

            sut.Insert(2, 42);

            Assert.AreEqual(3, sut.Count);
            Assert.AreEqual(2, sut[0]);
            Assert.AreEqual(1, sut[1]);
            Assert.AreEqual(42, sut[2]);
        }
    }
}