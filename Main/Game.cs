using System;
using System.Collections.Generic;
using static Play;

namespace WumpusGame
{
    public class Game
    {
        private Warrior Warrior;
        private Room CurrentRoom;
        private Room Entrance;

        public Game(Room entrance, Warrior warrior)
        {
            this.Entrance = entrance;
            this.CurrentRoom = entrance;
            this.Warrior = warrior;
        }

        public void start()
        {
            Result next = null;

            while (true)
            {
                Console.Clear();

                next = readChoiceFor(CurrentRoom);

                if (next is GameOver || next is Victory)
                {
                    if (playAgain())
                        refreshGameStatus();
                    else
                        break;
                }
            }
        }

        private bool playAgain()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Play again? Press [N] to leave...");
            String result = Console.ReadLine();

            return result.ToUpper() != "N";
        }

        private void refreshGameStatus()
        {
            CurrentRoom = Entrance;
            Warrior.Arrows = 3;
            Room.hasSupply = true;
        }

        private Result readChoiceFor(Room currentRoom)
        {
            Play moveOrShoot = readMoveOrShoot();

            Room target = readWhereToMoveOrShoot(moveOrShoot);

            return doMoveOrShoot(target, moveOrShoot);
        }

        private Play readMoveOrShoot()
        {
            presentTrap(CurrentRoom);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"   Room {0}           Room {1}       Room {2}      Room {3}", CurrentRoom, CurrentRoom.FrontRoom, CurrentRoom.LeftRoom, CurrentRoom.RightRoom);
            Console.WriteLine(@"   _____        ?     ____        ____        ____");
            Console.WriteLine(@"  / you \      O     /    \      /    \      /    \  ---\__O");
            Console.WriteLine(@"  | are |    /|\     |   o|      |   o|      |   o|        |\ ({0} Arrows Left)", Warrior.Arrows);
            Console.WriteLine(@" _| here|_   / \    _|    |_    _|    |_    _|    |_      / \ ");
            Console.WriteLine(@"            [M]ove                                      [S]hoot ");
            Console.WriteLine();

            Console.Write(" [M]ove or [S]hoot? ");

            do
            {
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "M":
                        return Move;
                    case "S":
                        return Shoot;
                    default:
                        showInvalidEntry(" Invalid option!", "[M]ove or [S]hoot? ");
                        break;
                }

            } while (true);
        }

        private Result doMoveOrShoot(Room target, Play moveOrShoot)
        {
            if (moveOrShoot == Move)
                return moveTo(target);
            else
                return shootTo(target);
        }

        private Result shootTo(Room target)
        {
            return target.getShot(Warrior);
        }

        private Result moveTo(Room target)
        {
            
            Result result = target.getIn(Warrior);

            if (result is Room)
                CurrentRoom = (Room)result;

            return result;
        }

        private Room readWhereToMoveOrShoot(Play play)
        {
            Console.Write(" Which room? ");

            do
            {
                int roomNumber = 0;

                try
                {
                    roomNumber = Convert.ToInt16(Console.ReadLine());

                    if (roomNumber == CurrentRoom.FrontRoom.Number)
                        return CurrentRoom.FrontRoom;
                    else if (roomNumber == CurrentRoom.LeftRoom.Number)
                        return CurrentRoom.LeftRoom;
                    else if (roomNumber == CurrentRoom.RightRoom.Number)
                        return CurrentRoom.RightRoom;
                    else
                        throw new Exception();

                }
                catch (Exception)
                {
                    showInvalidEntry(String.Format(" Dimwit! You can't get to there from here. There are tunnels to rooms {0}, {1}, and {2}.",
                        CurrentRoom.FrontRoom, CurrentRoom.LeftRoom, CurrentRoom.RightRoom), "Which room? ");
                }


            } while (true);
        }

        private void showInvalidEntry(string message, string label = "")
        {
            Console.WriteLine(message);
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            Console.WriteLine(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 3);
            Console.WriteLine(" " + label + new String(' ', Console.WindowWidth - label.Length));
            Console.SetCursorPosition(label.Length + 1, Console.CursorTop - 2);
        }

        private void presentTrap(Room currentRoom)
        {
            currentRoom.FrontRoom.Trap.presentSign();
            currentRoom.LeftRoom.Trap.presentSign();
            currentRoom.RightRoom.Trap.presentSign();
        }
    }
}

