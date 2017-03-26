using System;

namespace WumpusGame
{
    public class GameOver : Result
    {
        public GameOver()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\tG A M E   O V E R");
            Console.ReadKey();
        }
    }
}