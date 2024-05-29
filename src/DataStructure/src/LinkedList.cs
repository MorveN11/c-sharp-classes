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
