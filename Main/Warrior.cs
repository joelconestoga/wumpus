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
            if(Arrows == 0)
            {
                if(Room.hasSupply)
                {
                    Console.WriteLine("   You don't have any Arrows left.");
                    Console.WriteLine("   Find the supply room to continue!");
                    Console.ReadKey();
                    return null;
                } else if(!Room.hasSupply)
                {
                    Console.WriteLine("   You have spent your last Arrow!");
                    Console.WriteLine("   Press any key to exit...");
                    return new GameOver();
                }
            }

            Arrows--;
            return null;
        }
    }
}