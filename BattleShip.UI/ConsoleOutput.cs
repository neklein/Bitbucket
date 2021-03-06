﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public void OutputWelcome()
        {
            Console.WriteLine("Welcome to Battleship! Press any key to continue...");
            Console.ReadKey();


        }

        public void Player1PlaceShipMessage()
        {
            Console.WriteLine("Player 1! Time to start placing ships! Press any key to continue...");
            Console.ReadKey();
        }

        public void Player2PlaceShipMessage()
        {
            Console.WriteLine("Player 2! Time to start placing ships! Press any key to continue...");
            Console.ReadKey();
        }


        public void GiveUserShipPlacementNotesNotEnoughSpace()
        {
                Console.WriteLine($"There is not enough space for your ship in that location. Please enter new coordinates. Press any key to continue...");
                Console.ReadKey();
            
        }

        public void GiveUserShipPlacementNotesOverlapsAnotherShip()
        {
            Console.WriteLine($"There is already another ship in that space. Please enter new coordinates. Press any key to continue...");
            Console.ReadKey();

        }

        public void ThatIsADuplicateShip()
        {
            Console.WriteLine("That ship has already been placed. Please enter another.");
        }

        public void GiveUserShipPlacementNotesSuccess()
        {
            Console.WriteLine($"The ship is placed! Press any key to continue...");
            Console.ReadKey();

        }



        public void FirstTurnSelection()
        {
            Console.WriteLine("Now that ships are placed, we will flip a coin to see who will go first! Press any key to continue...");
            Console.ReadKey();

        }

        public void GiveUserShotFiredMessage()
        {
            Console.WriteLine("The shot is fired! Will it hit? Press any key to see!");
            Console.ReadKey();

        }

        public void OutputTheShotHit()
        {
            Console.WriteLine("That shot struck gold! A hit! Press any key for the next player...");
            Console.ReadKey();

        }

        public void OutputTheShotMiss()
        {
            Console.WriteLine("That shot splashed into the water! A miss! Press any key for the next player...");
            Console.ReadKey();

        }

        public void OutputTheShotInvalid()
        {
            Console.WriteLine("That is not a valid location. Please fire again. Press any key for the next player...");
            Console.ReadKey();

        }

        public void OutputTheShotDuplicate()
        {
            Console.WriteLine("That is a duplicate location. Please fire again. Press any key for the next player...");
            Console.ReadKey();

        }


        public void OutputHitAndSunk()
        {
            Console.WriteLine("Hit and sunk! Press any key to view the ship you sunk! ");
            Console.ReadKey();

        }

        public void OutputVictory()
        {
            Console.WriteLine("Congratulations! You have won the game!");
            Console.ReadKey();

        }

        public void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? Press 'Y' to play again or 'N' to exit.");
        }



    }
}
