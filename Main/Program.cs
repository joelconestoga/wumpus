using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Room entrance = new FileReader("EntryFile.csv").readFile();

            Warrior warrior = new Warrior(3);

            Game game = new Game(entrance, warrior);

            Console.WriteLine("\n\tLet the game begin... (Hit any key to start)");
            Console.ReadKey();

            game.start();

        }
    }
}
