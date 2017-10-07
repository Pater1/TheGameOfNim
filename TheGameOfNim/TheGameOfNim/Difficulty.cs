using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameOfNim {
    public enum Difficulty {
        EASY = 0,
        MEDUIM = 1,
        HARD = 2
    }
    public static class DifficultyExtentions {
        private static readonly Dictionary<Difficulty, Heap[]> difficultyHeaps = new Dictionary<Difficulty, Heap[]>() {
            {Difficulty.EASY, new Heap[]{
                    new Heap(2),
                    new Heap(2)
                }
            },
            {Difficulty.MEDUIM, new Heap[]{
                    new Heap(2),
                    new Heap(5),
                    new Heap(7)
                }
            },
            {Difficulty.HARD, new Heap[]{
                    new Heap(2),
                    new Heap(3),
                    new Heap(8),
                    new Heap(9)
                }
            },
        };

        public static Heap[] GetHeaps(this Difficulty _difficulty) {
            if (!difficultyHeaps.ContainsKey(_difficulty)) {
                return null;
            } else {
                return difficultyHeaps[_difficulty];
            }
        }
    }
}
