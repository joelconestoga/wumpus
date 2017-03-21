using System;

namespace WumpusGame
{
    public class Victory: Result
    {
        public Victory()
        {
            Console.WriteLine("   ** Y O U   W I N! **");
            Console.ReadKey();
        }
    }
}