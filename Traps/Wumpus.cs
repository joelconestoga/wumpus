using System;

namespace WumpusGame
{
    public class Wumpus : ITrap
    {
        public Result getShot()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Yess!! You killed the Wumpus!!");
            Console.ReadKey();

            return new Victory();
        }

        public Result getIn(Warrior warrior)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"   ^---^");
            Console.WriteLine(@"  / Ô ô \");
            Console.WriteLine(@" /  ___  \    Noooo!! The Wumpus!! Ahhhh...");
            Console.WriteLine(@" | |' '| |");
            Console.WriteLine(@" |_^---^_|");
            Console.WriteLine();

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