using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms {
    public class KnightsDialer {
        private readonly Dictionary<int, int[]> neighborMap;

        public KnightsDialer() {
            this.neighborMap = new Dictionary<int, int[]> () { 
                { 1, new int[] { 6, 8 } }, 
                { 2, new int[] { 7, 9 } }, 
                { 3, new int[] { 4, 8 } }, 
                { 4, new int[] { 0, 3, 9 } },
                { 5, new int[0] }, 
                { 6, new int[] { 0, 1, 7 } }, 
                { 7, new int[] { 2, 6 } }, 
                { 8, new int[] { 1, 3 } }, 
                { 9, new int[] { 2, 4 } }, 
                { 0, new int[] { 4, 6 } }
            };
        }

        public void Run () {
            var result = CountDistinctNumbers (6, 2);
            Console.WriteLine ("result (6,2): {0}", result);

            var result2 = CountDistinctNumbers (6, 3);
            Console.WriteLine ("result (6,3): {0}", result2);

            var result3 = CountDistinctNumbers (1, 3);
            Console.WriteLine ("result (1,3): {0}", result3);

            var result4 = CountDistinctNumbers (4, 3);
            Console.WriteLine ("result (4,3): {0}", result4);
        }

        public int CountDistinctNumbers (int startingNumber, int numOfHops) {
            var distinctNumbers = new List<int> ();
            distinctNumbers.Add (startingNumber);

            if (numOfHops >= 0) {
                distinctNumbers = GetDistinctNumbers (distinctNumbers, startingNumber, numOfHops);
            }

            // foreach (var distinctNum in distinctNumbers.Distinct()) {
            //     Console.WriteLine (distinctNum);
            // }

            return distinctNumbers.Distinct ().Count ();
        }

        public List<int> GetDistinctNumbers (List<int> distinctNumbers, int startingNumber, int numOfHops) {
            var neighbors = new List<int> ();
            var position = startingNumber;

            while(numOfHops > 0)
            {
                neighbors = (GetNeighbors (position)).ToList (); //(6, 2) -> 0, 1, 7

                foreach (var neighbor in neighbors)
                { 
                    if (!distinctNumbers.Contains (neighbor))
                    {
                        distinctNumbers.Add (neighbor);
                        //Console.WriteLine(neighbor);
                    }

                    distinctNumbers = GetDistinctNumbers (distinctNumbers, neighbor, numOfHops - 1); //(0, 1)
                }

                numOfHops = numOfHops - 1;
            }

            return distinctNumbers;
        }

        public int[] GetNeighbors (int startingNumber) {
            return neighborMap[startingNumber];
        }

    }
}