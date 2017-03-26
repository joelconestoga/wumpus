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
        public ITrap Trap { get; set; }

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

        public Result getShot(Warrior warrior)
        {
            if (warrior.isOutOfArrow())
                return lookForSupply();

            warrior.spendArrow();

            Result result = Trap.getShot();

            if (result is Victory)
                return result;

            return warrior.isOutOfArrow() ? lookForSupply() : this;
        }

        private Result lookForSupply()
        {
            if (hasSupply)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" You don't have any Arrows left.");
                Console.WriteLine(" Find the supply room to continue!");
                Console.ReadKey();

                return null;
            }

            return new GameOver();
        }

        public Result getIn(Warrior warrior)
        {
            if(this.Supply)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" You step into the Supply Room. You get more arrows! Yay!");
                Console.WriteLine(" (P.S. Extra Supply is over now)");
                Console.WriteLine(" Press any key to continue...");
                warrior.Arrows += 3;
                this.Supply = false;
                Room.hasSupply = false;
                Console.ReadKey();
                return this;
            }

            Result result = Trap.getIn(warrior);
            return result == null ? this : result;
        }
    }
}
