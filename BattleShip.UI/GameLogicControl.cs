using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class GameLogicControl
    {


        public GameLogicControl()
        {

        }

        Board Player1Board = new Board();
        Board Player2Board = new Board();

        public GameLogicControl(Board A, Board B)
        {
            A = Player1Board;
            B = Player2Board;
        }


        string Player1;
        string Player2;

        Random _rng = new Random();
        int TurnSelector = 0;
        string SelectThatTurn;

        ConsoleOutput GiveMessagesToUser = new ConsoleOutput();


        public void WelcomeMessage()
        {
            ConsoleOutput Welcome = new ConsoleOutput();
            Welcome.OutputWelcome();
        }

        public void GetName()
        {
            UserInput Name = new UserInput();
            Name.GetUserName();
            Player1 = Name._name1;
            Player2 = Name._name2;

        }



        public void GetShip()
        {
            ShipAndShotHistory DrawingBoard = new ShipAndShotHistory();

            UserInput PlaceThatShip = new UserInput();
            GiveMessagesToUser.Player1PlaceShipMessage();

            
            for (int i = 0; i < Player1Board.Ships.Length; i++)
            {
                PlaceShipRequest Player1Ship = PlaceThatShip.InputShipRequest();
                ShipPlacement response;

                //for ShipPlacement.NotEnoughSpace or .Overlap...I need additional things (cases?)
                while (true)
                {
                    response = Player1Board.PlaceShip(Player1Ship);
                    if (response == ShipPlacement.NotEnoughSpace)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesNotEnoughSpace();
                        Player1Ship = PlaceThatShip.InputShipRequest();
                        DrawingBoard.DrawBoard(Player1Board);
                        continue;
                    }
                    if (response == ShipPlacement.Overlap)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesOverlapsAnotherShip();
                        Player1Ship = PlaceThatShip.InputShipRequest();
                        DrawingBoard.DrawBoard(Player1Board);

                        continue;
                    }
                    if(response == ShipPlacement.Ok)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesSuccess();
                        DrawingBoard.DrawBoard(Player1Board);

                        break;
                    }


                }
                
            }

            Console.Clear();
            GiveMessagesToUser.Player2PlaceShipMessage();

            for (int i = 0; i < Player2Board.Ships.Length; i++)
            {
                PlaceShipRequest Player2Ship = PlaceThatShip.InputShipRequest();
                ShipPlacement response;

                while (true)
                {
                    response = Player2Board.PlaceShip(Player2Ship);
                    if (response == ShipPlacement.NotEnoughSpace)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesNotEnoughSpace();
                        Player2Ship = PlaceThatShip.InputShipRequest();
                        DrawingBoard.DrawBoard(Player2Board);

                        continue;
                    }
                    if (response == ShipPlacement.Overlap)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesOverlapsAnotherShip();
                        Player2Ship = PlaceThatShip.InputShipRequest();
                        DrawingBoard.DrawBoard(Player2Board);

                        continue;
                    }
                    if (response == ShipPlacement.Ok)
                    {
                        GiveMessagesToUser.GiveUserShipPlacementNotesSuccess();
                        DrawingBoard.DrawBoard(Player2Board);

                        break;
                    }                       
                }

            }

        }

        public string FirstTurnSelection()
        {
            string FirstTurn;
            TurnSelector = _rng.Next(1, 3);

            if (TurnSelector == 1)
                FirstTurn = Player1;
            else
                FirstTurn = Player2;

            Console.WriteLine($"{FirstTurn} is the starting player! Press any key to continue...");
            Console.ReadKey();

            SelectThatTurn = FirstTurn;
            return SelectThatTurn;

        }

        public void ShotsFired()
        {
            //need to transfer these over to UserInput somehow

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{SelectThatTurn}, please enter the X coordinate for your shot.");
                int CoordinateX = int.Parse(Console.ReadLine());

                Console.WriteLine($"{SelectThatTurn}, please enter the Y coordinate for your shot.");
                int CoordinateY = int.Parse(Console.ReadLine());
                Coordinate Shot = new Coordinate(CoordinateX, CoordinateY);
                FireShotResponse response;

                ConsoleOutput FireAway = new ConsoleOutput();
                FireAway.GiveUserShotFiredMessage();

                switch (TurnSelector)
                {
                    case 1:

                        response = Player2Board.FireShot(Shot);
                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Invalid:
                                response.ShotStatus = ShotStatus.Invalid;
                                FireAway.OutputTheShotInvalid();

                                break;
                            case ShotStatus.Duplicate:
                                response.ShotStatus = ShotStatus.Duplicate;
                                FireAway.OutputTheShotDuplicate();
                                break;
                            case ShotStatus.Miss:
                                response.ShotStatus = ShotStatus.Miss;
                                FireAway.OutputTheShotMiss();
                                break;
                            case ShotStatus.Hit:
                                response.ShotStatus = ShotStatus.Hit;
                                FireAway.OutputTheShotHit();
                                break;
                            case ShotStatus.HitAndSunk:
                                response.ShotStatus = ShotStatus.HitAndSunk;
                                FireAway.OutputHitAndSunk();
                                break;
                            case ShotStatus.Victory:
                                response.ShotStatus = ShotStatus.Victory;
                                FireAway.OutputVictory();
                                break;

                        }

                        TurnSelector = 2;
                        SelectThatTurn = Player2;

                        if (response.ShotStatus == ShotStatus.Duplicate || response.ShotStatus == ShotStatus.Duplicate)
                        {
                            TurnSelector = 1;
                            SelectThatTurn = Player1;
                            
                        }
                        if (response.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            //which ship was sunk?
                            //display ship here?;
                        }

                        if (response.ShotStatus == ShotStatus.Victory)
                        {
                            //need to check victory conditions
                            break;
                        }


                        continue;
                    case 2:
                        response = Player1Board.FireShot(Shot);

                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Invalid:
                                response.ShotStatus = ShotStatus.Invalid;
                                FireAway.OutputTheShotInvalid();

                                break;
                            case ShotStatus.Duplicate:
                                response.ShotStatus = ShotStatus.Duplicate;
                                FireAway.OutputTheShotDuplicate();
                                break;
                            case ShotStatus.Miss:
                                response.ShotStatus = ShotStatus.Miss;
                                FireAway.OutputTheShotMiss();
                                break;
                            case ShotStatus.Hit:
                                response.ShotStatus = ShotStatus.Hit;
                                FireAway.OutputTheShotHit();
                                break;
                            case ShotStatus.HitAndSunk:
                                response.ShotStatus = ShotStatus.HitAndSunk;
                                FireAway.OutputHitAndSunk();
                                break;
                            case ShotStatus.Victory:
                                response.ShotStatus = ShotStatus.Victory;
                                FireAway.OutputVictory();
                                break;

                        }

                        TurnSelector = 1;
                        SelectThatTurn = Player1;

                        if (response.ShotStatus == ShotStatus.Duplicate || response.ShotStatus == ShotStatus.Duplicate)
                        {
                            TurnSelector = 2;
                            SelectThatTurn = Player2;
                        }
                        if(response.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            //which ship was sunk?
                            //Need to display the sunken ship;
                        }

                        if (response.ShotStatus == ShotStatus.Victory)
                        {
                            //need to check victory conditions
                            break;
                        }

                        continue;


                }


            
            }

        }

        public void ConcludingTheGame()
        {
            ConsoleOutput TheEnd = new ConsoleOutput();

            TheEnd.PlayAgain();
        }
    }
}
