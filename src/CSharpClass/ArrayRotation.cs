namespace CSharpClass
{
    public enum RotationDirection
    {
        Left,
        Right
    }

    public class ArrayRotation<T>
    {
        private readonly T[] _array;

        public ArrayRotation(T[] array, int rotationCount, RotationDirection direction)
        {
            _array = rotateArray(array, rotationCount, direction);
        }

        public T[] GetArray()
        {
            return _array;
        }

        private int rotationCountValidation(T[] array, int rotationCount)
        {
            if (rotationCount < 0)
            {
                throw new ArgumentException("Rotation count must be a positive number");
            }

            if (rotationCount > array.Length)
            {
                rotationCount = rotationCount % array.Length;
            }

            return rotationCount;
        }

        private T[] rotateArray(T[] array, int rotationCount, RotationDirection direction)
        {
            var result = new T[array.Length];

            rotationCount = rotationCountValidation(array, rotationCount);

            for (int i = 0; i < array.Length; i++)
            {
                var newIndex =
                    direction == RotationDirection.Right
                        ? (i + rotationCount) % array.Length
                        : (i + array.Length - rotationCount) % array.Length;

                result[newIndex] = array[i];
            }

            return result;
        }
    }
}
