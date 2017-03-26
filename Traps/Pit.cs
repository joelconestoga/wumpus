using System;

namespace WumpusGame
{
    internal class Pit : ITrap
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
            Console.WriteLine(@" __--~~~~--~__");
            Console.WriteLine(@"   \^|^|^|^/    It's a trap!! Ahhh...");
            Console.WriteLine();

            return new GameOver(); ;
        }

        public void presentSign()
        {
            Console.WriteLine(@" __--~~~~--~__");
            Console.WriteLine(@"   \^|^|^|^/    ..You smell a dank odor.");
            Console.WriteLine();
        }
    }
}