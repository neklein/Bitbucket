using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ShipAndShotHistory
    {


        public void DrawBoard(Board PlayerBoard)
        {



            for (int currentX = 1; currentX < 11; currentX++)
            {
                for (int currentY = 1; currentY < 11; currentY++)
                {

                    for (int currentShip = 0; currentShip < PlayerBoard.Ships.Length; currentShip++)
                    {

                        var myCoord = new Coordinate(currentX, currentY);
                        if (PlayerBoard.Ships[currentShip] == null)
                        {
                            continue;
                        }
                        var positions = PlayerBoard.Ships[currentShip].BoardPositions;



                        for (int currentPosition = 0; currentPosition < positions.Length; currentPosition++)
                        {


                            if (positions[currentPosition] == myCoord)
                            {
                                if (PlayerBoard.Ships[currentShip].ShipType == ShipType.Destroyer)
                                    Console.Write("D");
                                else if (PlayerBoard.Ships[currentShip].ShipType == ShipType.Submarine)
                                    Console.Write("S");
                                else if (PlayerBoard.Ships[currentShip].ShipType == ShipType.Cruiser)
                                    Console.Write("C");
                                else if (PlayerBoard.Ships[currentShip].ShipType == ShipType.Battleship)
                                    Console.Write("B");
                                else if (PlayerBoard.Ships[currentShip].ShipType == ShipType.Carrier)
                                    Console.Write("C");
                                else Console.Write("_");
                            }


                        }
                    }

                }
                Console.WriteLine();

            }
        }

        public void ShowShotHistory(Board PlayerBoard)
        {
            for (int currentX = 1; currentX < 11; currentX++)
            {
                for (int currentY = 1; currentY < 11; currentY++)
                {
                    Coordinate myCoord = new Coordinate(currentX, currentY);
                    PlayerBoard.CheckCoordinate(myCoord);

                    if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Hit) Console.Write("H");
                    else if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Miss) Console.Write("M");
                    else if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Unknown) Console.Write("_");
                }
                Console.WriteLine();
            }
        }
    }





}
