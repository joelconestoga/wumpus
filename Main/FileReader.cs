using System;
using System.Collections.Generic;
using System.IO;
using WumpusGame;

namespace WumpusGame
{
    class FileReader
    {
        private const string ENTRY_FILE = "EntryFile2.csv";

        private string fileName;
        private TextReader file;

        private static Room[] allRooms = null;

        private int totalNumberOfRooms;
        private int totalSpiderRooms;
        private int totalPitRooms;

        HashSet<int> randomNumbers = new HashSet<int>();

        public FileReader(string fileName)
        {
            this.fileName = fileName;
        }

        public Room readFile()
        {
            file = new StreamReader(ENTRY_FILE);

            readTotalsOfRoomsAndTraps();

            createRoomInstances();

            createTunnels();

            SetupTraps();

            // Close the stream.
            file.Close();

            return allRooms[0];
        }

        private void readTotalsOfRoomsAndTraps()
        {
            string[] firstLine = file.ReadLine().Split(',');

            totalNumberOfRooms = int.Parse(firstLine[0]);
            totalSpiderRooms = int.Parse(firstLine[1]);
            totalPitRooms = int.Parse(firstLine[2]);

            allRooms = new Room[totalNumberOfRooms];
        }

        private void createRoomInstances()
        {
            Console.WriteLine("=== ROOMS ===");

            for (int i = 0; i < totalNumberOfRooms; i++)
            {
                string roomData = file.ReadLine();
                Console.WriteLine(" " + roomData);

                string[] roomDataSplit = roomData.Split(',');

                int number = int.Parse(roomDataSplit[0]);
                string sign = roomDataSplit[1];

                allRooms[i] = new Room(number, sign);
            }
        }

        private void createTunnels()
        {
            Console.WriteLine("\n=== TUNNELS ===");

            for (int i = 0; i < totalNumberOfRooms; i++)
            {
                string roomTunnels = file.ReadLine();
                Console.WriteLine(" " + roomTunnels);
                string[] roomTunnelsSplit = roomTunnels.Split(',');
                allRooms[i].FrontRoom = allRooms[(int.Parse(roomTunnelsSplit[1]) - 1)];
                allRooms[i].LeftRoom = allRooms[(int.Parse(roomTunnelsSplit[2]) - 1)];
                allRooms[i].RightRoom = allRooms[(int.Parse(roomTunnelsSplit[3]) - 1)];
            }
        }

        private void SetupTraps()
        {
            Console.WriteLine("\n=== TRAPS ===");

            int randomRoomIndex = 0;
            
            for (int i = 0; i < totalSpiderRooms; i++)
            {
                randomRoomIndex = generateRandomNumber();
                allRooms[randomRoomIndex].Trap = new Spider();
                Console.WriteLine(" Placed Spider in Room " + (randomRoomIndex + 1));
            }

            for (int i = 0; i < totalPitRooms; i++)
            {
                randomRoomIndex = generateRandomNumber();
                allRooms[randomRoomIndex].Trap = new Pit();
                Console.WriteLine(" Placed Pit in Room " + (randomRoomIndex + 1));
            }

            randomRoomIndex = generateRandomNumber();
            allRooms[randomRoomIndex].Trap = new Wumpus();
            Console.WriteLine(" Placed Wumpus in Room " + (randomRoomIndex + 1));

            randomRoomIndex = generateRandomNumber();
            allRooms[randomRoomIndex].Supply = true;
            Console.WriteLine(" Placed Supply in Room " + (randomRoomIndex + 1));
            
            randomRoomIndex = generateRandomNumber();
            allRooms[randomRoomIndex].Trap = new Bat(allRooms[randomRoomIndex]);
            Console.WriteLine(" Placed Bats in Room " + (randomRoomIndex + 1));
        }

        private int generateRandomNumber()
        {
            Random random = new Random();
            int number = 0;

            do
            {
                number = random.Next(1, (allRooms.Length - 1));
            }
            while (randomNumbers.Contains(number));

            randomNumbers.Add(number);

            return number;
        }

    }
}