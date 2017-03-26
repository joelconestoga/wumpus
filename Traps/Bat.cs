using System;
using WumpusGame;

namespace WumpusGame
{
    class Bat : ITrap
    {
        private Room batRoom;

        public Bat(Room room)
        {
            batRoom = room;
        }

        public Result getIn(Warrior warrior)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@" /-^..^-\");
            Console.WriteLine(@"       /-^..^-\  Bats!! Where are you taking me???...");
            Console.WriteLine(@" /-^..^-\");
            Console.ReadKey();

            Room moveTo = batRoom;

            Random random = new Random();

            for (int i = 0; i < 2; i++)
            {
                
                switch (random.Next(1, 3))
                {
                    case 1:
                        moveTo = moveTo.RightRoom;
                        break;
                    case 2:
                        moveTo = moveTo.LeftRoom;
                        break;
                    case 3:
                        moveTo = moveTo.FrontRoom;
                        break;
                    default:
                        break;
                }
            }

            // Avoid looping between bat rooms
            if (moveTo == batRoom)
                return moveTo.RightRoom;
            
            Result result = moveTo.getIn(warrior);

            return result == null ? moveTo : result;
        }

        public Result getShot()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Your arrow goes down the tunnel and is lost. You missed.");
            Console.ReadKey();
            return null;
        }

        public void presentSign()
        {
            Console.WriteLine(@" /-^..^-\");
            Console.WriteLine(@"       /-^..^-\  ..Flap, flap...");
            Console.WriteLine(@" /-^..^-\");
            Console.WriteLine();
        }
    }
}