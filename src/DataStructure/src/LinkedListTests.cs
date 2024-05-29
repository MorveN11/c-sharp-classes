using NUnit.Framework;

namespace DataStructure
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Test_Add()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.That(3, Is.EqualTo(list.Count));
            Assert.That(1, Is.EqualTo(list[0]));
            Assert.That(2, Is.EqualTo(list[1]));
            Assert.That(3, Is.EqualTo(list[2]));
        }

        [Test]
        public void Test_Clear()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.That(0, Is.EqualTo(list.Count));
        }

        [Test]
        public void Test_Contains()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.That(list.Contains(1), Is.True);
            Assert.That(list.Contains(3), Is.False);
        }

        [Test]
        public void Test_CopyTo()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            var array = new int[2];
            list.CopyTo(array, 0);
            Assert.That(1, Is.EqualTo(array[0]));
            Assert.That(2, Is.EqualTo(array[1]));
        }

        [Test]
        public void Test_IndexOf()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.That(0, Is.EqualTo(list.IndexOf(1)));
            Assert.That(1, Is.EqualTo(list.IndexOf(2)));
            Assert.That(-1, Is.EqualTo(list.IndexOf(3)));
        }

        [Test]
        public void Test_Insert()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);
            Assert.That(1, Is.EqualTo(list[0]));
            Assert.That(2, Is.EqualTo(list[1]));
            Assert.That(3, Is.EqualTo(list[2]));
        }

        [Test]
        public void Test_Remove()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Remove(1);
            Assert.That(1, Is.EqualTo(list.Count));
            Assert.That(2, Is.EqualTo(list[0]));
        }

        [Test]
        public void Test_RemoveAt()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);
            Assert.That(1, Is.EqualTo(list.Count));
            Assert.That(2, Is.EqualTo(list[0]));
        }

        [Test]
        public void Test_Iterator()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.That(new[] { 1, 2, 3 }, Is.EqualTo(list.ToArray()));
        }
    }
}
