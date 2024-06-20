namespace DataStructure
{
    public class Node<T> : IDisposable
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        public void Dispose()
        {
            Next = null;
        }
    }
}
