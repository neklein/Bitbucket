using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class GameLogicControl
    {
        Board Player1Board = new Board();
        Board Player2Board = new Board();

        string Player1;
        string Player2;



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
            UserInput PlaceThatShip = new UserInput();
            for (int i = 0; i < Player1Board.Ships.Length; i++)
            {
                PlaceShipRequest Player1Ship = PlaceThatShip.InputShipRequest();
                var response = Player1Board.PlaceShip(Player1Ship);
                Console.WriteLine($"the status of your ship placement is {response}");
                //something+= Player1Board.PlaceShip(Player1Ship);? 
                //I would initialize it at the top. Also, why no errors?

            }

            for (int i = 0; i < Player2Board.Ships.Length; i++)
            {
                PlaceShipRequest Player2Ship = PlaceThatShip.InputShipRequest();
               var response = Player2Board.PlaceShip(Player2Ship);

            }

        }

        public void SetupBoard()
        {

        }
    }
}
