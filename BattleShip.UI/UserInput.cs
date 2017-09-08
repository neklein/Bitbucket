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

            int CoordinateX;

            while (true)
            {
                Console.WriteLine("Player, select the board location for your ship. Please enter the X coordinate.");
                string InputX = Console.ReadLine();

                if (int.TryParse(InputX, out CoordinateX))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid coordinate. Please enter a valid Coordinate");
                    continue;
                }

            }

            int CoordinateY;


            while (true)
            {
                Console.WriteLine("Player, select the board location for your ship. Please enter the Y coordinate.");
                string InputY = Console.ReadLine();

                if (int.TryParse(InputY, out CoordinateY))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid coordinate. Please enter a valid Coordinate.");
                    continue;
                }
            }

            Coordinate NewShipCoordinate = new Coordinate (CoordinateX, CoordinateY);
            RequestToReturn.Coordinate = NewShipCoordinate;


            int direction;

            while (true)
            {
                Console.WriteLine("Player, please select a ship direction: 0 = Up, 1 = Down, 2 = Left, or 3 = Right.");
                string InputDirection = Console.ReadLine();
                
                if (int.TryParse(InputDirection, out direction))
                {
                    if(!(direction >= 0 || direction < 4))
                    {
                        Console.WriteLine("That is not a valid direction");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid direction. Please enter a valid direction.");
                    continue;
                }

            }

            switch (direction)
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

            int NewShip;
            while (true)
            {
                Console.WriteLine("Now enter the number associated with the ship type: 0 = Destroyer, 1 = Submarine, 2 = Cruiser, 3 = Battleship, 4 = Carrier");
                string shipType = Console.ReadLine();

                if (int.TryParse(shipType, out NewShip))
                {
                    
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid valid ship. Please enter a valid ship.");
                    continue;
                }
            }


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
