using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    struct Move
    {
        public readonly MoveDirection direction;
        public readonly bool pushedCrate;

        public Move(MoveDirection dir, bool pushedCrate)
        {
            direction = dir;
            this.pushedCrate = pushedCrate;
        }

        public MoveDirection GetOppositeDirection()
        {
            return direction ^ MoveDirection.Up; //flipping the last bit
        }
    }
}
