using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfNim {
    public class Heap {
        private int stones = 0;
        public int StonesLeft {
            get {
                return stones;
            }
        }

        private HeapUserControl display;
        public HeapUserControl Display {
            get {
                return display;
            }
            set {
                display = value;
                if (value != null) {
                    if (value.HeapRef != this) {
                        value.HeapRef = this;
                    }
                } else {
                    if(display != null) {
                        value.HeapRef = null;
                    }
                }
            }
        }

        public Heap(int stonesCount) {
            stones = stonesCount < 0? 0: stonesCount;
        }

        public bool RemoveStones(int count) {
            bool valid = stones > 0;

            if (valid) {
                stones -= count;
                display.Render();
            }

            return valid;
        }
    }
}
