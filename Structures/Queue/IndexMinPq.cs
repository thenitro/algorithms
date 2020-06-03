using System;

namespace Algorithms.Structure.Queue
{
    public class IndexMinPq<T> where T: IComparable
    {
        private readonly int _maxN;
        private int _n;

        private readonly int[] _pq;
        private readonly int[] _qp;

        private readonly T[] _keys;
        
        public IndexMinPq(int maxN)
        {
            if (maxN < 0)
            {
                throw new ArgumentOutOfRangeException("maxN");
            }

            _maxN = maxN;
            _n = 0;
            
            _keys = new T[maxN + 1];
            
            _pq = new int[maxN + 1];
            _qp = new int[maxN + 1];

            for (var i = 0; i <= maxN; i++)
            {
                _qp[i] = -1;
            }
        }

        public bool IsEmpty()
        {
            return _n == 0;
        }

        public bool Contains(int i)
        {
            ValidateIndex(i);
            return _qp[i] != -1;
        }

        public int Count()
        {
            return _n;
        }

        public void Insert(int i, T key)
        {
            ValidateIndex(i);
            if (Contains(i))
            {
                throw new ArgumentException("Index is already in priority queue");
            }

            _n++;

            _qp[i] = _n;
            _pq[_n] = i;

            _keys[i] = key;

            Swim(_n);
        }

        public int MinIndex()
        {
            if (_n == 0)
            {
                throw new ArgumentException("PriorityQueue underflow");
            }

            return _pq[1];
        }

        public T MinKey()
        {
            if (_n == 0)
            {
                throw new ArgumentException("PriorityQueue underflow");
            }

            return _keys[_pq[1]];
        }

        public int DelMin()
        {
            if (_n == 0)
            {
                throw new ArgumentException("PriorityQueue underflow");
            }

            var min = _pq[1];
            
            Exchange(1, _n--);
            Sink(1);

            _qp[min] = -1;
            _keys[min] = default(T);
            _pq[_n + 1] = -1;

            return min;
        }

        public T KeyOf(int i)
        {
            ValidateIndex(i);
            if (!Contains(i))
            {
                throw new ArgumentOutOfRangeException("i", "no such index in priority queue");
            }

            return _keys[i];
        }

        public void ChangeKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i))
            {
                throw new ArgumentOutOfRangeException("i", "no such index in priority queue");
            }

            _keys[i] = key;

            Swim(_qp[i]);
            Sink(_qp[i]);
        }

        public void DescreaseKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i))
            {
                throw new ArgumentOutOfRangeException("i", "no such index in priority queue");
            }

            if (_keys[i].CompareTo(key) == 0)
            {
                throw new ArgumentOutOfRangeException("key", "key is equal to current key");
            }
            
            if (_keys[i].CompareTo(key) < 0)
            {
                throw new ArgumentOutOfRangeException("key", "key is more than key in pq");
            }

            _keys[i] = key;

            Swim(_qp[i]);
        }

        public void IncreaseKey(int i, T key)
        {
            ValidateIndex(i);
            if (!Contains(i))
            {
                throw new ArgumentOutOfRangeException("i", "no such index in priority queue");
            }

            if (_keys[i].CompareTo(key) == 0)
            {
                throw new ArgumentOutOfRangeException("key", "key is equal to current key");
            }
            
            if (_keys[i].CompareTo(key) > 0)
            {
                throw new ArgumentOutOfRangeException("key", "key is less than key in pq");
            }

            _keys[i] = key;
            
            Sink(_qp[i]);
        }

        public void Delete(int i)
        {
            ValidateIndex(i);
            
            if (!Contains(i))
            {
                throw new ArgumentOutOfRangeException("i", "no such index in priority queue");
            }

            var index = _qp[i];
            Exchange(index, _n--);
            Swim(index);
            Sink(index);
            _keys[i] = default(T);
            _qp[i] = -1;
        }

        private void ValidateIndex(int i)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("i", "Index is negative");
            }

            if (i >= _maxN)
            {
                throw new ArgumentOutOfRangeException("i", "Index is more than capacity");
            }
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= _n)
            {
                var j = 2 * k;
                if (j < _n && Greater(j, j + 1))
                {
                    j++;
                }

                if (!Greater(k, j))
                {
                    break;
                }
                
                Exchange(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j)
        {
            return _keys[_pq[i]].CompareTo(_keys[_pq[j]]) > 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;

            _qp[_pq[i]] = i;
            _qp[_pq[j]] = j;
        }
    }
}