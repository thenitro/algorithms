using System.Collections.Generic;

namespace Algorithms.Structure.Tree
{
    internal class TrieNode
    {
        private const int AlphabetSize = 26;
        
        public TrieNode[] Children = new TrieNode[AlphabetSize];
        public bool IsEndOfWord = false;
    }
}