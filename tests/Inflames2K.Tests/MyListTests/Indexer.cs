using System;
using NUnit.Framework;

namespace Inflames2K.Tests.MyListTests
{
    [TestFixture]
    public class Indexer
    {
        [Test]
        public void Get_negative_index___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var actual = sut[-1];
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void Get_on_new_list___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<object>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var actual = sut[0];
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void Get_0___returns_first_element()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            var actual = sut[0];

            Assert.AreEqual(1, actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Get_1___returns_second_element()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            var actual = sut[1];

            Assert.AreEqual(2, actual);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Get_3___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var actual = sut[3];
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void Set_negative_index___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut[-1] = 42;
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void Set_on_new_list___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<object>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut[0] = new object();
            });
        }
        //---------------------------------------------------------------------
        [Test]
        public void Set_0___first_element_changed()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            sut[0] = 42;

            Assert.AreEqual(42, sut[0]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Set_1___second_element_changed()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            sut[1] = 42;

            Assert.AreEqual(42, sut[1]);
        }
        //---------------------------------------------------------------------
        [Test]
        public void Set_3___throws_ArgumentOutOfRange()
        {
            var sut = new MyList<int>();

            sut.Add(1);
            sut.Add(2);
            sut.Add(3);

            Assume.That(sut.Count, Is.EqualTo(3));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut[3] = 42;
            });
        }
    }
}