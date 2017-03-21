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

        internal Result spendArrow()
        {
            Arrows--;

            if (Arrows == 0)
            {
                Console.WriteLine("   You've spent your last arrow!");
                Console.ReadKey();
                return new GameOver();
            }

            return null;
        }
    }
}

