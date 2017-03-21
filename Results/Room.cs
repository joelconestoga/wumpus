using System;

namespace WumpusGame
{
    public class Room : Result
    {
        public int Number { get; set; }
        public string Sign { get; set; }
        public Room FrontRoom { get; internal set; }
        public Room LeftRoom { get; internal set; }
        public Room RightRoom { get; internal set; }
        public Trap Trap { get; set; }

        public Room(int number, string sign)
        {
            this.Number = number;
            this.Sign = sign;
            Trap = new TrapFree();
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public Result getShot()
        {
            return Trap.getShot();
        }

        public Result getIn()
        {
            Result result = Trap.getIn();
            return result == null ? this : result;
        }
    }
}
