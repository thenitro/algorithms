namespace Algorithms.Structure.UnionFind
{
    public class QuickUnion
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
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            var i = Root(p);
            var j = Root(q);

            _id[i] = j;
        }
        
        private int Root(int i)
        {
            while (i != _id[i])
            {
                i = _id[i];
            }

            return i;
        }
    }
}