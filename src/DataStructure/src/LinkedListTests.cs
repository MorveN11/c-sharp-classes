using NUnit.Framework;

namespace DataStructure
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void Test_Enumerator()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            IEnumerator<int> enumerator = list.GetEnumerator();

            Assert.That(enumerator.Current, Is.EqualTo(default(int)));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(1));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(2));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(3));
            Assert.That(enumerator.MoveNext(), Is.False);

            enumerator.Reset();

            Assert.That(enumerator.Current, Is.EqualTo(default(int)));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(1));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(2));
            Assert.That(enumerator.MoveNext(), Is.True);
            Assert.That(enumerator.Current, Is.EqualTo(3));
            Assert.That(enumerator.MoveNext(), Is.False);
        }

        [Test]
        public void Test_Add()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo(1));
            Assert.That(list[1], Is.EqualTo(2));
            Assert.That(list[2], Is.EqualTo(3));
        }

        [Test]
        public void Test_Clear()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));
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
            Assert.That(array[0], Is.EqualTo(1));
            Assert.That(array[1], Is.EqualTo(2));
        }

        [Test]
        public void Test_IndexOf()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.That(list.IndexOf(1), Is.EqualTo(0));
            Assert.That(list.IndexOf(2), Is.EqualTo(1));
            Assert.That(list.IndexOf(3), Is.EqualTo(-1));
        }

        [Test]
        public void Test_Insert()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);
            Assert.That(list[0], Is.EqualTo(1));
            Assert.That(list[1], Is.EqualTo(2));
            Assert.That(list[2], Is.EqualTo(3));
        }

        [Test]
        public void Test_Remove()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Remove(1);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo(2));
        }

        [Test]
        public void Test_RemoveAt()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0], Is.EqualTo(2));
        }

        [Test]
        public void Test_Iterator()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.That(list.ToArray(), Is.EqualTo(new[] { 1, 2, 3 }));
        }
    }
}
