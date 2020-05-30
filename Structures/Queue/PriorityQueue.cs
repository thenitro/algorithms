using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Algorithms.Structure.Queue
{
    public class PriorityQueue<T>
    {
        private List<IComparable<T>> _list = new List<IComparable<T>>();

        public PriorityQueue()
        {
        }

        public bool IsEmpty => _list.Count == 0;

        public void Enqueue(IComparable<T> item)
        {
            var count = _list.Count;
            if (count == 0)
            {
                _list.Add(item);
            }
            else
            {
                var i = 0;
                
                for (i = count - 1; i >= 0; i--)
                {   
                    if (item.CompareTo((T)_list[i]) < 1)
                    {
                        WriteValue(i, _list[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                WriteValue(i, item);
            }
        }

        public IComparable<T> Dequeue()
        {
            if (_list.Count == 0)
            {
                return null;
            }
            
            var item = _list[_list.Count - 1];
            
            _list.RemoveAt(_list.Count - 1);

            return item;
        }

        public IComparable<T> DelMin()
        {
            var item = _list[0];

            _list.RemoveAt(0);
            
            return item;
        }
        
        private void WriteValue(int i, IComparable<T> item)
        {
            var index = i + 1;
            
            if (index >= _list.Count - 1)
            {
                _list.Insert(i + 1, item);
            }
            else
            {
                _list[index] = item;                            
            }
        }

        public override string ToString()
        {
            var str = " ";

            foreach (var i in _list)
            {
                str += i + " ";
            }
            
            return "[PriorityQueue" + str + "]";
        }
    }
}