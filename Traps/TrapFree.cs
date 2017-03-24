using System;

namespace WumpusGame
{
    public class TrapFree : Trap
    {
        public Result getShot()
        {
            Console.WriteLine(" Your arrow goes down the tunnel and is lost. You missed.");
            Console.ReadKey();
            return null;
        }

        public Result getIn()
        {
            return null;
        }

        public void presentSign()
        {
            
        }
    }
}