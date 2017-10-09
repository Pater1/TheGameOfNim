using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheGameOfNim;
using System.Collections.Generic;

namespace NimUnitTests {

    [TestClass]
    public class HeapTests {

        [TestMethod]
        public void HeapTest() {
            List<Heap[]> heaps = new List<Heap[]>();
            heaps.Add(DifficultyExtentions.GetHeaps(Difficulty.EASY));
            heaps.Add(DifficultyExtentions.GetHeaps(Difficulty.MEDUIM));
            heaps.Add(DifficultyExtentions.GetHeaps(Difficulty.HARD));
            foreach(Heap[] h in heaps)
            {
                foreach(Heap heap in h)
                {
                    Assert.IsFalse(heap.RemoveStones(heap.StonesLeft + 1));
                }
            }
        }
    }
}
