using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Algorithms.Structure.Tree
{
    public class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
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

        public List<string> GetSuggestions(string query)
        {
            var result = new List<string>();
            
            var crawl = _root;
            var length = query.Length;

            for (var level = 0; level < length; level++)
            {
                var index = query[level] - 'a';

                if (crawl.Children[index] == null)
                {
                    return result;
                }

                crawl = crawl.Children[index];
            }

            var isWord = crawl.IsEndOfWord == true;
            var isLast = IsEmpty(crawl);

            if (isWord && isLast)
            {
                return result;
            }

            if (!isLast)
            {
                GetSuggestionsHelper(crawl, query, result);
            }

            return result;
        }

        private void GetSuggestionsHelper(TrieNode root, string currentPrefix, List<string> result)
        {
            if (root.IsEndOfWord)
            {
                result.Add(currentPrefix);
            }

            if (IsEmpty(root))
            {
                return;
            }

            for (var i = 0; i < root.Children.Length; i++)
            {
                if (root.Children[i] == null)
                {
                    continue;
                }

                currentPrefix += (char)(97 + i);
                GetSuggestionsHelper(root.Children[i], currentPrefix, result);
            }
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

        public string[] Keys()
        {
            var queue = new Queue<string>();
            Collect(_root, string.Empty, queue);
            return queue.ToArray();
        }

        private void Collect(TrieNode x, string prefix, Queue<string> q)
        {
            if (x == null)
            {
                return;
            }

            if (x.IsEndOfWord)
            {
                q.Enqueue(prefix);
            }

            for (var c = 0; c < TrieNode.AlphabetSize; c++)
            {
                Collect(x.Children[c], prefix + (char)(c + 'a'), q);
            }
        }

        public string LongestPrefixOf(string query)
        {
            var length = LongestPrefixOfHelper(_root, query, 0, 0);
            return query.Substring(0, length);
        }

        private int LongestPrefixOfHelper(TrieNode x, string query, int d, int length)
        {
            if (x == null)
            {
                return length;
            }

            if (x.IsEndOfWord)
            {
                length = d;
            }

            if (d == query.Length)
            {
                return length;
            }

            var c = query[d];
            return LongestPrefixOfHelper(x.Children[c - 'a'], query, d + 1, length);
        }
    }
}