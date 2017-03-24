
using System;

namespace WumpusGame
{
    public class Spider : Trap
    {
        public Result getShot()
        {
            Console.WriteLine(" Your arrow goes down the tunnel and is lost. You missed.");
            Console.ReadKey();
            return null;
        }

        public Result getIn()
        {
            Console.WriteLine(" Spiders!! Ahhhh...");
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