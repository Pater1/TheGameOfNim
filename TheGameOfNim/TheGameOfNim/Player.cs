using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfNim {
    public interface IPlayer {
        string Name { get; }
        bool MakeMove(Nim _game);
    }

    public abstract class Player: IPlayer {
        private readonly string name;
        public virtual string Name {
            get {
                return name;
            }
        }

        protected Player(string _name) {
            name = _name;
        }

        public abstract bool MakeMove(Nim _game);
    }
}
