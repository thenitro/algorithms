#Union Find data structure
###Also known as disjoint-set data structure or merge-find set
##How to use
Every implementation of algorithms shares same interface `IUnionFind`. 

`IUnionFind.Connected` - returns true if two items are connected.

`IUnionFind.Find` - returns set id of the item.

`IUnionFind.Unite` - unites two items in single set.

##Analysis
Operation | Quick Find | Quick Union | QuickUnionOptimized
------------ | ------------- |  ------------- | -------------
Memory | O(N) | O(N) | O(N)
Initialization | O(N) | O(N) | O(N)
Union | O(N) | O(N)* | O(log N)
Find | O(1) | O(N)* | O(log N)

(*) - it's worst case. In practice less likely to happen, but keep in mind.