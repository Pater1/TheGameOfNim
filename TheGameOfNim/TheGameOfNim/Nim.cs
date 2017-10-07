using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfNim {
    public class Nim {
        public Heap[] Heaps { get; private set; }

        public IPlayer[] Players { get; private set; } = new IPlayer[2];
        public IPlayer CurrentPlayer {
            get {
                return curIndex >= Players.Length ? null : Players[curIndex];
            }
        }
        private int curIndex = 0;
        public int CurrentPlayerIndex {
            get {
                return curIndex;
            }
            set {
                curIndex = value % Players.Length;
            }
        }

        private NimGamePage display;
        public NimGamePage Display {
            get {
                return display;
            }
            set {
                display = value;
                if (value != null) {
                    if (value.Game != this) {
                        value.Game = this;
                    }
                } else {
                    if (display != null) {
                        value.Game = null;
                    }
                }
            }
        }

        public Nim(Difficulty _difficulty, string _playerName) {
            Players[0] = new HumanPlayer(_playerName);
            Players[1] = new ComputerPlayer();

            CommonCtor(_difficulty);
        }
        public Nim(Difficulty _difficulty, string _player1Name, string _player2Name) {
            Players[0] = new HumanPlayer(_player1Name);
            Players[1] = new HumanPlayer(_player2Name);

            CommonCtor(_difficulty);
        }
        private void CommonCtor(Difficulty _difficulty) {
            Heaps = _difficulty.GetHeaps();
        }

        public bool RemoveStones(int count, int heap) {
            if(heap < 0 || heap > Heaps.Length) {
                return false;
            }

            return Heaps[heap].RemoveStones(count);
        }

        public IPlayer Winner { get; private set; } = null;
        public bool GameOver {
            get {
                return Winner != null;
            }
        }

        public void SwitchTurn() {
            CurrentPlayerIndex++;

            int totalStones = 0;
            foreach(Heap h in Heaps) {
                totalStones += h.StonesLeft;
            }
            if (totalStones > 0) {
                bool autoMoved = CurrentPlayer.MakeMove(this);
                Display.Update();
                if (autoMoved) {
                    SwitchTurn();
                }
            } else {
                Winner = CurrentPlayer;
                Display.Win();
            }
        }
    }
}
