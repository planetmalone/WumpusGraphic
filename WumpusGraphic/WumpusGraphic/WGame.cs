using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WumpusGraphic
{
    class WGame
    {
        private Board board;
        private Game game;
        private static string status;
        private static string turn;
        private static bool bumped;
        private static Room prevRoom;

        public WGame(Game game)
        {
            this.game = game;
            board = new Board();
            status = "Start";
            turn = "wumpus";
            bumped = false;
            prevRoom = Board.Player.Room;
        }

        /******************************************************************************************
         * Status Property
         * 
         * This property is static to allow for all other classes to access the sits array.
         *****************************************************************************************/
        public static string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }

        } // End Status

        public static void play()
        {
            // Get game status
            gameStatus();

            // Play piece
            if (turn == "Wumpus")
            {
                wumpusTurn();
            }
            else if (turn == "Player")
            {
                playerTurn();
            }
        }

        public static void gameStatus()
        {
            // Only update the status if the player moves
            if (Board.Player.Room != prevRoom)
            {
                // Set previous room to current room
                prevRoom = Board.Player.Room;

                // Wumpu's turn
                turn = "Wumpus";

                // Did the player bump the Wumpus
                if (bumped && Board.Wumpus.Room.Number == Board.Player.Room.Number)
                {
                    status = "Eaten";
                }
                else if (!bumped && Board.Wumpus.Room.Number == Board.Player.Room.Number)
                {
                    status = "Bumped";
                    bumped = true;
                    Board.Wumpus.Awake = true;
                }
                // Did the player fall into a pit?
                else if (Board.Player.Room.Hazard != null)
                {
                    if (Board.Player.Room.Hazard.Type == "pit")
                    {
                        status = "Pit";
                    }
                }
                // Room is empty
                else
                {
                    status = "Play";
                }
            }
            // Did a Superbat moved the player
            else if (Board.RandomMove)
            {
                Board.RandomMove = false;
                status = "Superbat";
            }
        }

        private static void wumpusTurn()
        {
            if (Board.Wumpus.Awake)
                Board.Wumpus.move();

            turn = "Player";
        }

        private static void playerTurn()
        {

        }
    }
}
