using System;
using System.Threading;

namespace TheGameOfNim {
    public class ComputerPlayer : Player {
        public ComputerPlayer() : base("CPU") {}

        Random rand = new Random();
        public override bool MakeMove(Nim _game) {
            Thread.Sleep(1000);

            bool valid = false;
            while (!valid) {
                int heap = rand.Next(0, _game.Heaps.Length);
                if(_game.Heaps[heap].StonesLeft > 0)
                    valid = _game.RemoveStones(rand.Next(1, _game.Heaps[heap].StonesLeft), heap);
            }
            return true;
        }
    }
}
