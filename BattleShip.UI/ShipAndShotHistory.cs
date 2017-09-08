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
                    bool ifShip = false;
                    
                    foreach (var ship in PlayerBoard.Ships)
                    {
                        if (ship == null)
                        {
                            continue;
                        }

                        if (ship != null)
                        {
                            var myCoord = new Coordinate(currentX, currentY);

                            if (ship.BoardPositions.Contains(myCoord))
                            {

                                if (ship.ShipType == ShipType.Destroyer)
                                {
                                    Console.Write("D");
                                    ifShip = true;
                                    break;

                                }
                                else if (ship.ShipType == ShipType.Submarine)
                                {
                                    Console.Write("S");
                                    ifShip = true;

                                    break;
                                }
                                else if (ship.ShipType == ShipType.Cruiser)
                                {
                                    Console.Write("C");
                                    ifShip = true;

                                    break;
                                }
                                else if (ship.ShipType == ShipType.Battleship)
                                {
                                    Console.Write("B");
                                    ifShip = true;

                                    break;
                                }
                                else if (ship.ShipType == ShipType.Carrier)
                                {
                                    Console.Write("C");
                                    ifShip = true;

                                    break;

                                }
                                

                            }


                        }
                    }
                    if (!ifShip)
                    {
                        Console.Write("_");
                        
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

                    if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("H");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("M");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else if (PlayerBoard.CheckCoordinate(myCoord) == ShotHistory.Unknown) Console.Write("_");
                }
                Console.WriteLine();
            }
        }
    }





}
