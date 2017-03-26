using System;

namespace WumpusGame
{
    public class TrapFree : ITrap
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
            return null;
        }

        public void presentSign()
        {
            
        }
    }
}