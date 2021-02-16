namespace Algorithms.Structure.UnionFind
{
    public interface IUnionFind
    {
        bool Connected(int p, int q);
        int Find(int x);
        void Union(int p, int q);
    }
}