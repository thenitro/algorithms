namespace Algorithms.Structure.UnionFind
{
    public class QuickUnion : IUnionFind
    {
        private int[] _id;

        public QuickUnion(int n)
        {
            _id = new int[n];

            for (var i = 0; i < n; i++)
            {
                _id[i] = i;
            }
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            var i = Find(p);
            var j = Find(q);

            _id[i] = j;
        }
        
        public int Find(int i)
        {
            while (i != _id[i])
            {
                i = _id[i];
            }

            return i;
        }
    }
}