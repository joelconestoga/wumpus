using System;

namespace WumpusGame
{
    public class Warrior
    {
        public int Arrows { get; set; }

        public Warrior(int arrows)
        {
            this.Arrows = arrows;
        }

        public Result spendArrow()
        {
            Arrows--;

            if (isOutOfArrow())
                Console.WriteLine(" You have spent your last Arrow!");

            return null;
        }

        public bool isOutOfArrow()
        {
            return Arrows < 1;
        }
    }
}