using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class UserInput
    {
        public string _name1;
        public string _name2;

        ShipAndShotHistory ShowTheBoard = new ShipAndShotHistory();


        public void GetUserName()
        {
            Console.WriteLine("You are player 1. Please enter your name: ");
            string name1 = Console.ReadLine();

            Console.WriteLine("You are player 2. Please enter your name: ");
            string name2 = Console.ReadLine();

            _name1 = name1;
            _name2 = name2;

            Console.WriteLine("Your board is available for ship placement. Please get ready to place your ships!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public PlaceShipRequest InputShipRequest()
        {
            PlaceShipRequest RequestToReturn = new PlaceShipRequest();

            Console.WriteLine("Player, select the board location for your ship. Please enter the X coordinate.");
            string CoordinateX = Console.ReadLine();

            Console.WriteLine("Player, please enter the Y coordinate.");
            string CoordinateY = Console.ReadLine();

            Coordinate ForShipCoordinate = new Coordinate(int.Parse(CoordinateX), int.Parse(CoordinateY));

            RequestToReturn.Coordinate = ForShipCoordinate;

            Console.WriteLine("Player, please select a ship direction: 0 = Left, 1 = right, 2 = up, or 3 = down.");

            //for later: need to change this to an int.TryParse, then alter the switch to reflect.
            int ForShipDirection = int.Parse(Console.ReadLine());

            switch (ForShipDirection)
            {
                
                case 0:
                    RequestToReturn.Direction = ShipDirection.Up;
                    break;
                case 1:
                    RequestToReturn.Direction = ShipDirection.Down;
                    break;
                case 2:
                    RequestToReturn.Direction = ShipDirection.Left;
                    break;
                case 3: RequestToReturn.Direction = ShipDirection.Right;
                    break;
            }

            Console.WriteLine("Now enter the number associated with the ship type: 0 = Destroyer, 1 = Submarine, 2 = Cruiser, 3 = Battleship, 4 = Carrier");
            int NewShip = int.Parse(Console.ReadLine());
            switch (NewShip)
            {
                case 0:
                    RequestToReturn.ShipType = ShipType.Destroyer;
                    break;
                case 1:
                    RequestToReturn.ShipType = ShipType.Submarine;
                    break;
                case 2:
                    RequestToReturn.ShipType = ShipType.Cruiser;
                    break;
                case 3:
                    RequestToReturn.ShipType = ShipType.Battleship;
                    break;
                case 4:
                    RequestToReturn.ShipType = ShipType.Carrier;
                    break;
            }

            return RequestToReturn;



        }


        //need input for coordinate locations to attack

    }
}
