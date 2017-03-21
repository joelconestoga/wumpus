using System;

namespace WumpusGame
{
    internal class Pit : Trap
    {
        public Result getShot()
        {
            Console.WriteLine("   Your arrow goes down the tunnel and is lost. You missed.");
            Console.ReadKey();
            return null;
        }

        public Result getIn()
        {
            Console.WriteLine("   It's a trap!! Ahhh...");
            return new GameOver(); ;
        }

        public void presentSign()
        {
            Console.WriteLine(@"   __--~~~~--~__");
            Console.WriteLine(@"     \^|^|^|^/    ..You smell a dank odor.");
            Console.WriteLine();

            //Console.WriteLine("You smell a dank odor.");
        }
    }
}