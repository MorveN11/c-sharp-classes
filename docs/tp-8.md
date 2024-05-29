# TP - 8 - C Sharp | Manuel Morales

## Que son los “properties”?

![ans properties](https://i.ibb.co/hdf6Hh4/Whats-App-Image-2024-05-29-at-13-09-24.jpg)

## Implementar una estructura de datos que represente una coleccion de items (Génerico)

- Implementar `IEnumerator<T>`
- Implementar `IList<T>`
- Implementar `IEnumerable<T>`
- No utilizer ningun tipo de EDD como campo de su implementacion
- A base de nodos, ejemplo

### Nodo

```csharp
namespace DataStructure
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
```

### Linked List

```csharp
using System.Collections;

namespace DataStructure
{
    public class LinkedList<T> : IEnumerator<T>, IEnumerable<T>, IList<T>
    {
        private Node<T>? _head;
        private Node<T>? _current;

        public T Current
        {
            get
            {
                if (_current == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return _current.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (Current == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return Current;
            }
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _head;
            }
            else
            {
                _current = _current.Next;
            }

            return _current != null;
        }

        public void Reset()
        {
            _current = null;
        }

        public void Dispose() { }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T>? GetNodeByIndex(int index)
        {
            int currentIndex = 0;
            Node<T>? currentNode = _head;

            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    return currentNode;
                }

                currentIndex++;
                currentNode = currentNode?.Next;
            }

            return null;
        }

        public T this[int index]
        {
            get
            {
                Node<T>? node = GetNodeByIndex(index);

                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return node.Value;
            }
            set
            {
                Node<T>? node = GetNodeByIndex(index);

                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }

                node.Value = value;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node<T>? currentNode = _head;

                while (currentNode != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                return count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new Node<T>(item);
                return;
            }

            Node<T>? currentNode = _head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new Node<T>(item);
        }

        public void Clear()
        {
            _head = null;
        }

        public bool Contains(T item)
        {
            Node<T>? currentNode = _head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T>? currentNode = _head;

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            while (currentNode != null)
            {
                array[arrayIndex++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public int IndexOf(T item)
        {
            int index = 0;
            Node<T>? currentNode = _head;

            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Value, item))
                {
                    return index;
                }

                index++;
                currentNode = currentNode.Next;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index == 0)
            {
                Node<T> newHead = new Node<T>(item) { Next = _head };
                _head = newHead;
                return;
            }

            Node<T>? currentNode = GetNodeByIndex(index - 1);

            if (currentNode == null)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> newNode = new Node<T>(item) { Next = currentNode.Next };

            currentNode.Next = newNode;
        }

        public bool Remove(T item)
        {
            if (_head == null)
            {
                return false;
            }

            if (EqualityComparer<T>.Default.Equals(_head.Value, item))
            {
                _head = _head.Next;
                return true;
            }

            Node<T>? currentNode = _head;

            while (currentNode.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentNode.Next.Value, item))
                {
                    currentNode.Next = currentNode.Next.Next;
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                if (_head == null)
                {
                    throw new IndexOutOfRangeException();
                }

                _head = _head.Next;
                return;
            }

            Node<T>? currentNode = GetNodeByIndex(index - 1);

            if (currentNode == null || currentNode.Next == null)
            {
                throw new IndexOutOfRangeException();
            }

            currentNode.Next = currentNode.Next.Next;
        }
    }
}
```

### Tests

```csharp
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
```

## Nombre todos los tipos de funciones que conozca y sus caracterisitcas

![ans types](https://i.ibb.co/k8vMGFF/2.jpg)

## Que es un Closure?

![ans closure](https://i.ibb.co/VWGGjTM/3.jpg)

## Extention Functions de las funciones: Filter, Map, Reduce

### Extesion Methods

```csharp
public static class ExtensionMethods
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> Map<T, TResult>(
        this IEnumerable<T> collection,
        Func<T, TResult> selector
    )
    {
        foreach (var item in collection)
        {
            yield return selector(item);
        }
    }

    public static TResult Reduce<T, TResult>(
        this IEnumerable<T> collection,
        Func<TResult, T, TResult> reducer,
        TResult initial
    )
    {
        var result = initial;

        foreach (var item in collection)
        {
            result = reducer(result, item);
        }

        return result;
    }
}
```

### Program

```csharp
class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };

        var evenNumbers = numbers.Filter(n => n % 2 == 0);
        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

        var squares = numbers.Map(n => n * n);
        Console.WriteLine("Squares: " + string.Join(", ", squares));

        var sum = numbers.Reduce((a, b) => a + b, 0);
        Console.WriteLine("Sum: " + sum);
    }
}

```

## Investigar el uso del token yield

![ans yield](https://i.ibb.co/LzbDSY3/4.jpg)
