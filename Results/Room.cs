using System;

namespace WumpusGame
{
    public class Room : Result
    {
        public static bool hasSupply = true;

        public int Number { get; set; }
        public string Sign { get; set; }
        public bool Supply { get; set; }
        public Room FrontRoom { get; internal set; }
        public Room LeftRoom { get; internal set; }
        public Room RightRoom { get; internal set; }
        public Trap Trap { get; set; }

        public Room(int number, string sign)
        {
            this.Number = number;
            this.Sign = sign;
            this.Supply = false;
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

        public Result getIn(Warrior warrior)
        {
            if(this.Supply)
            {
                Console.WriteLine("\n\nYou step into the Supply Room. You get more arrows! Yay!");
                Console.WriteLine("(P.S The Supply is over now)");
                Console.WriteLine("Press any key to continue...");
                warrior.Arrows += 3;
                this.Supply = false;
                Room.hasSupply = false;
                Console.ReadKey();
                return this;
            }

            Result result = Trap.getIn();
            return result == null ? this : result;
        }
    }
}
