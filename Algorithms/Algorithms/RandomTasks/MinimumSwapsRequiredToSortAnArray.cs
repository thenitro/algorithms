using System;
using System.Collections.Generic;

namespace Algorithms.RandomTests
{
    public class MinimumSwapsRequiredToSortAnArray
    {
        public MinimumSwapsRequiredToSortAnArray()
        {
            Console.WriteLine(2 == Solve(new int[] { 4, 3, 2, 1 }));
            Console.WriteLine(2 == Solve(new int[] { 1, 5, 4, 3, 2 }));
        }
        
        public int Solve(int[] arr)
        {
            var n = arr.Length; 
            var arrPositions = new List<Tuple<int, int>>();

            for (var i = 0; i < n; i++)
            {
                arrPositions.Add(new Tuple<int, int>(arr[i], i));
            }
            
            arrPositions.Sort((x,y) => x.Item1.CompareTo(y.Item1));
            
            var visited = new HashSet<int>();
            var result = 0;

            for (var i = 0; i < n; i++)
            {
                if (visited.Contains(i) || arrPositions[i].Item2 == i)
                {
                    continue;
                }

                var cycleSize = 0;
                var j = i;

                while (!visited.Contains(j))
                {
                    visited.Add(j);

                    j = arrPositions[j].Item2;
                    cycleSize++;
                }

                if (cycleSize > 0)
                {
                    result += (cycleSize - 1);
                }
            }

            return result;
        }
    }
}