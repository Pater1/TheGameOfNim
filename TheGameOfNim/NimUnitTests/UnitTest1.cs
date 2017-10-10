using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TheGameOfNim;

namespace NimUnitTests {

    /// <summary>
    /// Nim unit tests
    /// </summary>
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void SinglePlayerCtorTest() {
            foreach (Difficulty d in Enum.GetValues(typeof(Difficulty))) {
                Nim nim = new Nim(d, "p1");
                Assert.IsTrue(nim.Players[0].GetType() == typeof(HumanPlayer));
                Assert.IsTrue(nim.Players[1].GetType() == typeof(ComputerPlayer));
            }
        }

        [TestMethod]
        public void ComputerPlayerNameTest() {
            foreach (Difficulty d in Enum.GetValues(typeof(Difficulty))) {
                Nim nim = new Nim(d, "p1");
                Assert.AreEqual(nim.Players[1].Name, "CPU");
            }
        }

        [TestMethod]
        public void MultiPlayerCtorTest() {
            foreach (Difficulty d in Enum.GetValues(typeof(Difficulty))) {
                Nim nim = new Nim(d, "p1", "p2");
                Assert.IsTrue(nim.Players[0].GetType() == typeof(HumanPlayer));
                Assert.IsTrue(nim.Players[1].GetType() == typeof(HumanPlayer));
            }
        }

        [TestMethod]
        public void RemoveAllStonesTest() {
            foreach (Difficulty d in Enum.GetValues(typeof(Difficulty))) {
                Nim nim = new Nim(d, "p1") { Display = new NimGamePage() };
                for (int i = 0; i < nim.Heaps.Length; i++) {
                    bool removeResult = nim.RemoveStones(nim.Heaps[i].StonesLeft, i);
                    Assert.IsTrue(removeResult);
                }
            }
        }

        [TestMethod] 
        public void SwitchTurnTest() {
            foreach (Difficulty d in Enum.GetValues(typeof(Difficulty))) {
                Nim nim = new Nim(d, "p1") { Display = new NimGamePage() };
                IPlayer curPlayer = nim.CurrentPlayer;
                nim.SwitchTurn();

                // shouldn't equal each other, since the purpose of the method is just to switch whose turn it is
                Assert.AreNotEqual(curPlayer, nim.CurrentPlayer);
            }
        }

        [TestMethod]
        public void GameOverTest() {
            Nim nim = new Nim(Difficulty.EASY, "p1") { Display = new NimGamePage() };
            Assert.IsFalse(nim.GameOver);
        }
    }
}
