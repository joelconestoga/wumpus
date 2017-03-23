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

        public new Result getIn()
        {
            int[] randoms = new int[5];
            Room room = this;

            for (int i = 0; i < randoms.Length - 1; i++)
            {
                switch (randoms[i])
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
            return room is BatRoom ? room.FrontRoom : room.getIn();
        }
    }
}
