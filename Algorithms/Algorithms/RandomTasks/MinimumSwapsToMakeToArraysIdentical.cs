using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests
{
    public class MinimumSwapsToMakeToArraysIdentical
    {
        public MinimumSwapsToMakeToArraysIdentical()
        {
            Console.WriteLine(2 == Solve(new int[] { 3, 6, 4, 8}, new int[] { 4, 6, 8, 3}));
        }

        private int Solve(int[] arrayA, int[] arrayB)
        {
            var n = arrayA.Length;
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < n; i++)
            {
                dict[arrayB[i]] = i;
            }

            for (var i = 0; i < n; i++)
            {
                arrayB[i] = dict[arrayA[i]];
            }

            return MinSwapsToSort(arrayB, n);
        }

        private int MinSwapsToSort(int[] array, int n)
        {
            var arrayPosition = new List<Tuple<int, int>>();
            for (var i = 0; i < n; i++)
            {
                arrayPosition.Add(new Tuple<int, int>(array[i], i));
            }
            
            arrayPosition.Sort((x,y) => x.Item1.CompareTo(y.Item1));
            
            var visited = new HashSet<int>();
            var result = 0;

            for (var i = 0; i < n; i++)
            {
                if (visited.Contains(i) || arrayPosition[i].Item2 == i)
                {
                    continue;
                }

                var cycleSize = 0;
                var j = i;

                while (!visited.Contains(j))
                {
                    visited.Add(j);
                    j = arrayPosition[j].Item2;
                    cycleSize++;
                }

                result += cycleSize - 1;
            }

            return result;
        }
    }
}