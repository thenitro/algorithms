using Algorithms.Pathfinding;

namespace Algorithms.Structure.Tree.TernarySearchTrie
{
    public class Tst<T>
    {
        private Node _root;

        private class Node
        {
            public T Value;
            public char C;
            public Node Left;
            public Node Middle;
            public Node Right;
        }

        public void Put(string key, T value)
        {
            _root = Put(_root, key, value, 0);
        }

        private Node Put(Node x, string key, T value, int d)
        {
            var c = key[d];
            if (x == null)
            {
                x = new Node();
                x.C = c;
            }

            if (c < x.C)
            {
                x.Left = Put(x.Left, key, value, d);
            }
            else if (c > x.C)
            {
                x.Right = Put(x.Right, key, value, d);
            }
            else if (d < key.Length - 1)
            {
                x.Middle = Put(x.Middle, key, value, d + 1);
            }
            else
            {
                x.Value = value;
            }

            return x;
        }

        public bool Contains(string key)
        {
            var x = Get(_root, key, 0);
            return x != null;
        }

        public T Get(string key)
        {
            var x = Get(_root, key, 0);
            if (x == null)
            {
                return default(T);
            }

            return x.Value;
        }
        
        private Node Get(Node x, string key, int d)
        {
            if (x == null)
            {
                return null;
            }

            var c = key[d];
            if (c < x.C)
            {
                return Get(x.Left, key, d);
            }
            else if (c > x.C)
            {
                return Get(x.Right, key, d);
            } 
            else if (d < key.Length - 1)
            {
                return Get(x.Middle, key, d + 1);
            }
            else
            {
                return x;
            }
        }
    }
}