namespace Algorithms.Structure.UnionFind
{
    public class QuickFind : IUnionFind
    {
        private int[] _ids;

        public QuickFind(int n)
        {
            _ids = new int[n];

            for (var i = 0; i < n; i++)
            {
                _ids[i] = i;
            }
        }

        public bool Connected(int p, int q)
        {
            return _ids[p] == _ids[q];
        }

        public int Find(int x)
        {
            return _ids[x];
        }

        public void Union(int p, int q)
        {
            var pId = _ids[p];
            var qId = _ids[q];

            for (var i = 0; i < _ids.Length; i++)
            {
                if (_ids[i] == pId)
                {
                    _ids[i] = qId;
                }
            }
        }
    }
}