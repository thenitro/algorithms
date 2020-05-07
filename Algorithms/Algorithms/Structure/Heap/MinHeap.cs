namespace Algorithms.Structure.Heap
{
    public class MinHeap
    {
        private int _size;
        private int _capacity;
        private int[] _array;

        public MinHeap(int capacity)
        {
            _capacity = capacity;
            _size = 0;
            _array = new int[capacity];
        }

        public int Peek()
        {
            return _array[0];
        }

        public void Push(int value)
        {
            if (_size == _capacity)
            {
                return;
            }

            _size++;
            var i = _size - 1;
            _array[i] = value;

            while (i != 0 && _array[Parent(i)] > _array[i])
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public int Pop()
        {
            if (_size <= 0)
            {
                return int.MaxValue;
            }

            if (_size == 1)
            {
                _size--;
                return _array[0];
            }

            var root = _array[0];
            _array[0] = _array[_size - 1];
            _size--;
            
            Heapify(0);

            return root;
        }

        public void Decrease(int i, int newI)
        {
            _array[i] = newI;

            while (i != 0 && _array[Parent(i)] > _array[i])
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public void Delete(int value)
        {
            Decrease(value, int.MinValue);
            Pop();
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private int Left(int i)
        {
            return 2 * i + 1;
        } 
        
        private int Right(int i)
        {
            return 2 * i + 2;
        } 

        private void Swap(int i, int j)
        {
            var tmp = _array[i];
            _array[i] = _array[j];
            _array[j] = tmp;
        }

        private void Heapify(int i)
        {
            var l = Left(i);
            var r = Right(i);

            var smallest = i;

            if (l < _size && _array[l] < _array[i])
            {
                smallest = l;
            }

            if (r < _size && _array[r] < _array[smallest])
            {
                smallest = r;
            }

            if (smallest != i)
            {
                Swap(i, smallest);
                Heapify(smallest);
            }
        }
    }
}