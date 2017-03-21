using System;

namespace WumpusGame
{
    public class GameOver : Result
    {
        public GameOver()
        {
            Console.WriteLine("   G A M E   O V E R");
            Console.ReadKey();
        }
    }
}