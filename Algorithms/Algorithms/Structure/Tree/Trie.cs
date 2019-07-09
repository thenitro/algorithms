using System.Linq.Expressions;

namespace Algorithms.Structure.Tree
{
    public class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Print()
        {
            PrintHelper(_root, new char[20], 0);
        }
        
        public void Insert(string key)
        {
            var length = key.Length;
            var crawl = _root;

            for (var level = 0; level < length; level++)
            {
                var index = key[level] - 'a';
                
                if (crawl.Children[index] == null)
                {
                    crawl.Children[index] = new TrieNode();
                }

                crawl = crawl.Children[index];
            }

            crawl.IsEndOfWord = true;
        }

        public bool Search(string key)
        {
            var length = key.Length;
            var crawl = _root;

            for (var level = 0; level < length; level++)
            {
                var index = key[level] - 'a';
                
                if (crawl.Children[index] == null)
                {
                    return false;
                }

                crawl = crawl.Children[index];
            }

            return (crawl != null && crawl.IsEndOfWord);
        }

        public void Remove(string key)
        {
            RemoveHelper(_root, key, 0);
        }

        private TrieNode RemoveHelper(TrieNode root, string key, int depth)
        {
            if (root == null)
            {
                return null;
            }

            if (depth == key.Length)
            {
                if (root.IsEndOfWord)
                {
                    root.IsEndOfWord = false;
                }

                if (IsEmpty(root))
                {
                    root = null;
                }

                return root;
            }

            var index = key[depth] - 'a';

            root.Children[index] = RemoveHelper(root.Children[index], key, depth + 1);

            if (IsEmpty(root) && root.IsEndOfWord == false)
            {
                root = null;
            }

            return root;
        }

        private bool IsEmpty(TrieNode root)
        {
            for (var i = 0; i < root.Children.Length; i++)
            {
                if (root.Children[i] != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}