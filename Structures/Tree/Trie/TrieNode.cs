using System.Collections.Generic;

namespace Algorithms.Structure.Tree
{
    internal class TrieNode
    {
        public const int AlphabetSize = 26;
        
        public TrieNode[] Children = new TrieNode[AlphabetSize];
        public bool IsEndOfWord = false;
    }
}