using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WumpusGame
{
    public class Program
    {
        private static Room[] Rooms = null;

        public static void Main(string[] args)
        {
            Room entrance = readFile();

            Warrior warrior = new Warrior(3);

            Game game = new Game(entrance, warrior);

            Console.ReadKey();

            game.start();

        }

        private static Room readFile()
        {
            TextReader tr = new StreamReader("EntryFile.csv");

            // Read number of Rooms.
            string rooms = tr.ReadLine();
            string[] firstLine = rooms.Split(',');

            int totalNumberOfRooms = int.Parse(firstLine[0]);
            int totalSpiderRooms = int.Parse(firstLine[1]);
            int totalPitRooms = int.Parse(firstLine[2]);

            Rooms = new Room[totalNumberOfRooms];

            for (int i = 0; i < totalNumberOfRooms; i++)
            {
                string roomData = tr.ReadLine();
                Console.WriteLine(roomData);
                string[] roomDataSplit = roomData.Split(',');
                Console.WriteLine(roomDataSplit[0]);
                int thisRoom = int.Parse(roomDataSplit[0]);
                string sign = roomDataSplit[1];
                Room room = new Room(thisRoom, sign);
                Rooms[(thisRoom - 1)] = room;
                Console.WriteLine(room.Number);
            }

            for (int i = 0; i < totalNumberOfRooms; i++)
            {
                string roomTunnels = tr.ReadLine();
                Console.WriteLine(roomTunnels);
                string[] roomTunnelsSplit = roomTunnels.Split(',');
                Rooms[i].FrontRoom = Rooms[(int.Parse(roomTunnelsSplit[1]) - 1)];
                Rooms[i].LeftRoom = Rooms[(int.Parse(roomTunnelsSplit[2]) - 1)];
                Rooms[i].RightRoom = Rooms[(int.Parse(roomTunnelsSplit[3]) - 1)];
            }

            SetupTraps(totalSpiderRooms, totalPitRooms);

            // Close the stream.
            tr.Close();
            return Rooms[0];

        }

        private static void SetupTraps(int totalSpiderRooms, int totalPitRooms)
        {
            HashSet<int> randomNumbers = new HashSet<int>();
            int randomRoomIndex = 0;

            for(int i = 0; i < totalSpiderRooms; i++)
            {
                randomRoomIndex = GenerateRandomNumber(1, (Rooms.Length - 1), randomNumbers);
                Rooms[randomRoomIndex].Trap = new Spider();
                Console.WriteLine("Placed Spider in Room " + (randomRoomIndex + 1));
            }

            for (int i = 0; i < totalPitRooms; i++)
            {
                randomRoomIndex = GenerateRandomNumber(1, (Rooms.Length - 1), randomNumbers);
                Rooms[randomRoomIndex].Trap = new Pit();
                Console.WriteLine("Placed Pit in Room " + (randomRoomIndex + 1));
            }

            randomRoomIndex = GenerateRandomNumber(1, (Rooms.Length - 1), randomNumbers);
            Rooms[randomRoomIndex].Trap = new Wumpus();
            Console.WriteLine("Placed Wumpus in Room " + (randomRoomIndex + 1));

        }

        private static int GenerateRandomNumber(int start, int end, HashSet<int> randomNumbers)
        {
            Random rng = new Random();
            int number = 0;
            do
            {
                number = rng.Next(1, (Rooms.Length - 1));
            }
            while (randomNumbers.Contains(number));
            randomNumbers.Add(number);
            return number;

        }
    }
}
