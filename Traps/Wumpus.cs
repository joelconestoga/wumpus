using System;

namespace WumpusGame
{
    public class Wumpus : Trap
    {
        public Result getShot()
        {
            Console.WriteLine(" Aaarrrgghhh!! You killed the Wumpus!!");
            Console.ReadKey();

            return new Victory();
        }

        public Result getIn()
        {
            Console.WriteLine(" Noooo!! The Wumpus!! Ahhhh...");
            return new GameOver();
        }

        public void presentSign()
        {

            Console.WriteLine(@"   ^---^");
            Console.WriteLine(@"  / Ô ô \");
            Console.WriteLine(@" /  ___  \    ..You smell some nasty Wumpus!");
            Console.WriteLine(@" | |' '| |");
            Console.WriteLine(@" |_^---^_|");
            Console.WriteLine();
        }
    }
}