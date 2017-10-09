using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TheGameOfNim;

namespace NimUnitTests {
    [TestClass]
    public class DifficultyTests {
        [TestMethod]
        public void TestGetEasy() {
            Heap[] a = new Heap[]{
                    new Heap(2),
                    new Heap(2)
                };
            Heap[] q = Difficulty.EASY.GetHeaps();

            Assert.AreEqual(a.Length, q.Length);
            for (int i = 0; i < a.Length; i++) {
                Assert.AreEqual(a[i].StonesLeft, q[i].StonesLeft);
            }
        }
        [TestMethod]
        public void TestGetMedium() {
            Heap[] a = new Heap[]{
                    new Heap(2),
                    new Heap(5),
                    new Heap(7)
                };
            Heap[] q = Difficulty.MEDUIM.GetHeaps();

            Assert.AreEqual(a.Length, q.Length);
            for (int i = 0; i < a.Length; i++) {
                Assert.AreEqual(a[i].StonesLeft, q[i].StonesLeft);
            }
        }
        [TestMethod]
        public void TestGetHard() {
            Heap[] a = new Heap[]{
                    new Heap(2),
                    new Heap(3),
                    new Heap(8),
                    new Heap(9)
            };
            Heap[] q = Difficulty.HARD.GetHeaps();

            Assert.AreEqual(a.Length, q.Length);
            for (int i = 0; i < a.Length; i++) {
                Assert.AreEqual(a[i].StonesLeft, q[i].StonesLeft);
            }
        }
    }
}
