using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Room entrance = readFile();

            Warrior warrior = new Warrior(3);

            Game game = new Game(entrance, warrior);

            game.start();

        }

        private static Room readFile()
        {
            Room room1 = new Room(1, "Beware of the Wumpus!");

            Room room2 = new Room(2, "There is a black pool of water in the corner.");
            Room room3 = new Room(3, "You see a Tyrannosaurus Rex fossil embedded in the wall.");
            Room room4 = new Room(4, "There is an empty Diet Rite can here.");
            Room room5 = new Room(5, "You almost step on a broken cellular phone.");
            Room room6 = new Room(6, "A couple of evil rats stare at you from under a pile of rocks.");
            Room room7 = new Room(7, "You find a Spanish doubloon on the floor.");
            Room room8 = new Room(8, "The ceiling is very low and you have to stoop.");
            Room room9 = new Room(9, "You step on a slippery spot, slip, and fall on your keester.");
            Room room10 = new Room(10, "You get a strong sense of deja vu.");

            room1.FrontRoom = room2; room1.LeftRoom = room6; room1.RightRoom = room10;
            room2.FrontRoom = room1; room2.LeftRoom = room3; room2.RightRoom = room7;

            room3.FrontRoom = room2; room3.LeftRoom = room4; room3.RightRoom = room8;
            room3.Trap = new Pit();

            room4.FrontRoom = room3; room4.LeftRoom = room5; room4.RightRoom = room9;
            room5.FrontRoom = room4; room5.LeftRoom = room6; room5.RightRoom = room10;

            room6.FrontRoom = room1; room6.LeftRoom = room5; room6.RightRoom = room7;
            room6.Trap = new Spider();

            room7.FrontRoom = room2; room7.LeftRoom = room6; room7.RightRoom = room8;
            room7.Trap = new Wumpus();

            room8.FrontRoom = room3; room8.LeftRoom = room7; room8.RightRoom = room9;

            room9.FrontRoom = room4; room9.LeftRoom = room8; room9.RightRoom = room10;
            room10.FrontRoom = room1; room10.LeftRoom = room5; room10.RightRoom = room9;
            room10.Trap = new Spider();

            return room1;
        }
    }
}
