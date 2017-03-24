using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusGame
{
    class BatRoom : Room
    {
        public BatRoom(int number, string sign) : base(number, sign)
        {
            this.Number = number;
            this.Sign = sign;
        }

        public new Result getIn(Warrior warrior)
        {
            Room room = this;

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                switch (random.Next(1, 3))
                {
                    case 1:
                        room = room.FrontRoom;
                        break;
                    case 2:
                        room = room.LeftRoom;
                        break;
                    case 3:
                        room = room.RightRoom;
                        break;
                    default:
                        break;
                }
            }

            // Avoid looping between bat rooms
            return room is BatRoom ? room.FrontRoom : room.getIn(null);
        }
    }
}
