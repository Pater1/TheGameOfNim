using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfNim {
    public class HumanPlayer : Player {
        public HumanPlayer(string _name) : base(_name) {}

        public override bool MakeMove(Nim _game) {
            return false;
        }
    }
}
