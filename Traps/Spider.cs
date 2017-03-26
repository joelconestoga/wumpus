
using System;

namespace WumpusGame
{
    public class Spider : ITrap
    {
        public Result getShot()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Your arrow goes down the tunnel and is lost. You missed.");
            Console.ReadKey();
            return null;
        }

        public Result getIn(Warrior warrior)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"     __");
            Console.WriteLine(@" _/\/--\/\_   Spiders!! Ahhhh...");
            Console.WriteLine();

            return new GameOver();
        }

        public void presentSign()
        {
            Console.WriteLine(@"     __");
            Console.WriteLine(@" _/\/--\/\_   ..You hear a faint clicking noise.");
            Console.WriteLine();
        }
    }
}