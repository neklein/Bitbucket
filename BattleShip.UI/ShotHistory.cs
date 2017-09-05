using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class ShotHistory
    {
        ShotHistory CheckShots = new ShotHistory();
        FireShotResponse ShowHistory = new FireShotResponse();

        Board Player1 = new Board();
        Board Player2 = new Board();




        public void ShowShotHistory()
        {
            GameLogicControl GetBoards = new GameLogicControl(Player1, Player2);

            while (true)
            {

            }
        }
    }
}
