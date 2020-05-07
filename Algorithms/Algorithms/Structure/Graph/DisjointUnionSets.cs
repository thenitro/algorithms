namespace Algorithms.Structure
{
    public class DisjointUnionSets
    {
        private int _size;

        private int[] _rank;
        private int[] _parent;
        
        public DisjointUnionSets(int size)
        {
            _size = size;
            
            _rank = new int[size];
            _parent = new int[size];
            
            MakeSet();
        }

        public int Find(int x)
        {
            if (_parent[x] != x)
            {
                _parent[x] = Find(_parent[x]);
            }

            return _parent[x];
        }

        public void Union(int x, int y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX == rootY)
            {
                return;
            }

            if (_rank[rootX] < _rank[rootY])
            {
                _parent[rootX] = rootY;
            } 
            else if (_rank[rootY] < _rank[rootX])
            {
                _parent[rootY] = rootX;
            }
            else
            {
                _parent[rootY] = rootX;
                _rank[rootX] = _rank[rootX] + 1;
            }
        }

        private void MakeSet()
        {
            for (var i = 0; i < _size; i++)
            {
                _parent[i] = i;
            }
        }
    }
}